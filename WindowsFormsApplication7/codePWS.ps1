$taikhoan = get-credential
$IP=192.168.0.1
$test = gwmi win32_operatingsystem -comp $IP -credential $taikhoan
