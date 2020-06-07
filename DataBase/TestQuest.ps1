$UserList = New-Object System.Collections.ArrayList
$Format = 'yyyy-MM-dd 00:00:00'

#Заполняем информацию о пользователях
For ($i=0; $i -lt 100; $i++)
{

    $Daybirth = (10..30 | Get-Random -Count 1) * (-1)
    $Yearsbirth = (25..40 | Get-Random -Count 1) * (-1)
    $NameUser = -join ((65..90) | Get-Random -Count 10 | % {[char]$_})
    $BitEnabled = (0..1 | Get-Random -Count 1)
    $Dateofbirth = Get-Date ((Get-Date).AddDays($Daybirth)).AddYears($Yearsbirth) -Format $Format
    $curDate = Get-Date
    $Age = ($curDate - $(Get-Date $Dateofbirth))
    $Age = ($Age.Days/365)-(($Age.Days/365)%1)
    $Description = ((65..90) | Get-Random -Count 100 | % {[char]$_}) 
    
    $StrQuery = "
    INSERT INTO [Test].[dbo].[InfoUser]
                ([Dateofbirth]
               ,[NameUser]
               ,[Enabled]
               ,[Age]
               ,[Description])
    VALUES ('$Dateofbirth'
           ,'$NameUser'
           ,$BitEnabled
           ,$Age
           ,'$Description')"
    
    invoke-sqlcmd -server "Paradise" -Database "Test" -Query $StrQuery
}

#Собираем данные о пользователях в таблице
$StrQuery = "
    Select
        [NameUser]
       ,[Enabled]
    FROM [Test].[dbo].[InfoUser]"
    
$UserList.AddRange($(invoke-sqlcmd -server "Paradise" -Database "Test" -Query $StrQuery))

#Заполняем информацию о ПК исходя из имён пользователей, но убирая тех кто заблокирован
foreach ($CurUser in $UserList)
{
    IF ($CurUser.Enabled -ne $false)
    {
        $DateLoad = Get-Date -Format $Format
        $NamePC = -join ((65..90) | Get-Random -Count 15 | % {[char]$_})
        $Domain = "$(-join ((65..90) | Get-Random -Count 4 | % {[char]$_})).ru"
        $NameUser = $CurUser.NameUser
        [double]$HDDLoad = (15..100 | Get-Random -Count 1)/(2..7 | Get-Random -Count 1)
        $LatslogonTimeStamp = -join ((0..8 + 0..9 | Get-Random -Count 18))
        $Description = ((65..90) | Get-Random -Count 50 | % {[char]$_}) 

        $StrQuery = "
        INSERT INTO [Test].[dbo].[InfoPC]
                    ([DateLoad]
                   ,[NamePC]
                   ,[Domain]
                   ,[NameUser]
                   ,[HDDLoad]
                   ,[LatslogonTimeStamp]
                   ,[Description])
        VALUES ('$DateLoad'
               ,'$NamePC'
               ,'$Domain'
               ,'$NameUser'
               ,$HDDLoad
               ,$LatslogonTimeStamp
               ,'$Description')"
    
        invoke-sqlcmd -server "Paradise" -Database "Test" -Query $StrQuery
    }
}

#Заполняем третью таблицу о ошибках в АС исходя из имён пользователей, но убирая тех кто заблокирован
foreach ($CurUser in $UserList)
{
    IF ($CurUser.Enabled -ne $false)
    {
        For ($i=0; $i -lt (1..3 | Get-Random -Count 1); $i++)
        {
            $DateTimeJob = Get-Date -Format $Format
            $NameAC = -join ((65..90) | Get-Random -Count 20 | % {[char]$_})
            $Operator = $CurUser.NameUser
            $DirectoryFile = "C:\$(-join ((65..90) | Get-Random -Count 10 | % {[char]$_}))"
            $ErrorIDJob = (200,404,500 | Get-Random -Count 1)
            $ErrorLogJob = Switch ($ErrorIDJob) {
                                           200 {"Успешно"}
                                           404 {"Ошибка"}
                                           500 {"Ошибка2"}
                                       }
            $TransactMoney = (1..100 | Get-Random -Count 1)

            $StrQuery = "
            INSERT INTO [Test].[dbo].[InfoJobAS]
                        ([DateTimeJob]
                       ,[NameAC]
                       ,[Operator]
                       ,[DirectoryFile]
                       ,[ErrorIDJob]
                       ,[ErrorLogJob]
                       ,[TransactMoney])
            VALUES ('$DateTimeJob'
                   ,'$NameAC'
                   ,'$Operator'
                   ,'$DirectoryFile'
                   ,$ErrorIDJob
                   ,'$ErrorLogJob'
                   ,$TransactMoney)"
    
            invoke-sqlcmd -server "Paradise" -Database "Test" -Query $StrQuery
        }
    }
}