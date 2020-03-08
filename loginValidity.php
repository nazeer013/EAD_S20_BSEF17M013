<?php
	$username = "root";
    $passowrd = "";
    $server = "localhost";
    $databaseName = "user_data";

    $connect =  mysqli_connect($server,$username, $passowrd, $databaseName);
    if($connect->connect_error){
        die( "Error Connecting to database". $connect->connect_error);
    }
	
	if(isset($_REQUEST['login'])){
        $user = $_POST['user'];
        $password = $_POST['password'];
	if(empty($user) || empty($password)){
            echo "<script type='text/javascript'>
			alert('Empty fields');
			location = 'login.php';
			</script>";
            exit();
        } 
		else{
			echo"hello";
            $sql = "select * from user where username = '$user' and password = '$password'";
            $result = mysqli_query($connect, $sql);
            $row = mysqli_num_rows($result);
            if($row  == 0){
                  echo "<script type='text/javascript'>
                            alert('no user found');
							location = 'login.php';
                        </script>";
                    exit();
            }
			else{
				echo "<script type='text/javascript'>
                            alert('Logged in successfully');
							location = 'login.php';
                        </script>";
                    exit();
			}
				
        }
    }
?>