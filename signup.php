<?php
	$username = "root";
    $passowrd = "";
    $server = "localhost";
    $databaseName = "user_data";

    $connect =  mysqli_connect($server,$username, $passowrd, $databaseName);
    if($connect->connect_error){
        die( "Error Connecting to database". $connect->connect_error);
    }
	
	if(isset($_POST['signup']))
	{
		$user = $_POST['user'];
		$pasword = $_POST['password'];
		$cPassword = $_POST['confirmPassword'];
		if($pasword != $cPassword)
		{
			echo "<script type='text/javascript'>
			alert('Password doesn't match');
			location = 'login.php';
			</script>";
			exit();
		}
		$sql = "Select * from user where username = '$user'";
		$result = mysqli_query($connect, $sql);
		$row = mysqli_num_rows($result);
		if($row > 0){
			echo "<script type='text/javascript'>
			alert('User Already Registred');
			location = 'login.php';
			</script>";
			exit();
		}
		else{
			$sql = "insert into user (username, password) values  ('$user','$pasword')";
			$row = mysqli_query($connect, $sql) or die("Error occured");
			if ($row){
				echo "<script type='text/javascript'>
				alert('Successfully Registered');
				location = 'login.php';
				</script>";
				exit();
			}  
		}
	}
?>