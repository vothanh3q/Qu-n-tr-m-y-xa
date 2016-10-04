
$taikhoan = Get-Credential Administrator
$IP = '192.168.159.1'
$test=gwmi win32_operatingsystem -ComputerName $IP -Credential $taikhoan
if ($test -eq $null) 
   {
         Write-Host 'Tai khoan mat khau sai!'
         }
else
    {
        Write-Host 'Dang nhap vao IP :' $IP 'thanh cong'
        }