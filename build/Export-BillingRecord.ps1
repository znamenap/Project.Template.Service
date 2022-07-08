[CmdletBinding()]
param(
    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string] $Path = "$PSScriptRoot\billing-records.csv",

    [Parameter()]
    [ValidateSet("Daily", "Weekly", "Monthly", "Quarterly")]
    [string] $Period = "Monthly",

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [datetime] $Valuation = [datetime]::Today
)
process {
    $Path = $PSCmdLet.GetUnresolvedProviderPathFromPSPath($Path)
    if ($Period -eq "Daily") {
        $BeginDate = $Valuation
        $EndDate = $Valuation.AddDays(1).AddSeconds(-1)
    } elseif ($Period -eq "Weekly") {
        $BeginDate = $Valuation.AddDays(-[int]($Valuation.DayOfWeek)+1)
        $EndDate = $BeginDate.AddDays(8).AddSeconds(-1)
    } elseif ($Period -eq "Monthly") {
        $BeginDate = $Valuation.AddDays(-$Valuation.Day+1)
        $EndDate = $BeginDate.AddMonths(1).AddSeconds(-1)
    } elseif ($Period -eq "Quarterly") {
        $BeginDate = $Valuation.AddMonths(- ($Valuation.Month % 3) + 1).AddDays(-$Valuation.Day+1)
        $EndDate = $BeginDate.AddMonths(3).AddSeconds(-1)
    }
    Write-Verbose "Path: $Path"
    Write-Verbose ("BeginDate: {0:s}" -f $BeginDate)
    Write-Verbose ("EndDate: {0:s}" -f $EndDate)
    $Records = Import-Csv -Path $Path -Delimiter ',' |
        ForEach-Object {
            Add-Member -Force -InputObject $_ -NotePropertyName StartAt -NotePropertyValue ([datetime]($_.StartAt))
            Add-Member -Force -InputObject $_ -NotePropertyName StopAt -NotePropertyValue ([datetime]($_.StopAt))
            Add-Member -Force -InputObject $_ -NotePropertyName Minutes -NotePropertyValue (([datetime]($_.StopAt))-([datetime]($_.StartAt))).TotalMinutes
            Write-Output $_
        } | Where-Object { $_.StartAt -ge $BeginDate -and $_.StopAt -le $EndDate }
    $Sum = $Records| Measure-Object -Property Minutes -Sum -Average -Maximum -Minimum
    $Records | Format-Table -AutoSize -Property Minutes, StartAt, StopAt, Activity | Out-String -Width $Host.UI.RawUI.BufferSize.Width | Out-Host
    $Hours = [int] ([math]::Truncate($Sum.Sum / 60))
    $Minutes = [int] ($Sum.Sum % 60)
    $AdjustedHours = $Hours
    $AdjustedMinutes = if ( $Minutes -ge 45 ) { 00 ; $AdjustedHours += 1 }
                   elseif ( $Minutes -ge 30 ) { 30 }
                   elseif ( $Minutes -ge 15 ) { 30 }
                   elseif ( $Minutes -ge 00 ) { 00 }
    $DecimalHours = $AdjustedHours + ($AdjustedMinutes / 60)
    $Summary = ('{0} minutes => {1:D2}:{2:D2} => {3:D2}:{4:D2} => {5:F2} hrs' -f ($Sum.Sum), $Hours, $Minutes, $AdjustedHours, $AdjustedMinutes, $DecimalHours)
    $Report = [ordered] @{
        'Period type' = $Period
        'Begin date' = $BeginDate
        'End date' = $EndDate
        'Minutes in total' = $Sum.Sum
        'Minutes on average' = [math]::Truncate($Sum.Average)
        'Input hours' = $Hours
        'Input minutes' = $Minutes
        'Adjusted hours' = $AdjustedHours
        'Adjusted minutes' = $AdjustedMinutes
        'Decimal hours' = $DecimalHours
        'Summary' = $Summary
    }
    New-Object -TypeName psobject -Property $Report
}
