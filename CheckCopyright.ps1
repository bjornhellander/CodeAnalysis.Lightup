$notice = 'Copyright © Björn Hellander 2024'

$files = Get-ChildItem -Path . -File -Recurse

$filesWithoutPattern = @()
foreach ($file in $files) {
    if ($file.FullName -like '*\bin\*') {
        continue
    }
    
    if ($file.FullName -like '*\obj\*') {
        continue
    }
    
    if ($file.FullName -like '*\*.csproj') {
        continue
    }
    
    $content = Get-Content -Path $file.FullName -Raw

    if ($content -notmatch $notice) {
        $filesWithoutPattern += $file.FullName
    }
}

Write-Host "Files that do not contain a copyright notice:"
$filesWithoutPattern | ForEach-Object { Write-Host $_ }
