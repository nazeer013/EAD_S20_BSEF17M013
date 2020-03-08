<html>
<head>
        <title> ****USER LOGIN**** </title>
        <link rel="stylesheet" type="text/css" href="style.css">
        <link rel="stylesheet" type= "text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css ">
</head>
<body>
    <div class='container'>
        <div class= 'login-box'>
        <div class='row'>
           <div class ="col-md-6 login-left">
                <h2> Login Here </h2>
                <form action="loginValidate.php" method="post">
                    <div class="from-group">
                        <label>Username</label>
                        <input type="text" name="user" class="form-control" required>
                    </div>
                    <div class="from-group">
                        <label>Password</label>
                        <input type="password" name="password" class="form-control" required>
                     </div>
					 <div class="from-group">
                        <input type="submit" name="login" value="Login" class="btn btn-primary">
                    </div>
                </form>    
            </div>
            <div class ="col-md-6 login-right">
                <h2> Sign-Up Here </h2>
                <form action="signup.php" method="post">
                    <div class="from-group">
                        <label>Username</label>
                        <input type="text" name="user" class="form-control" required>
                    </div>
                    <div class="from-group">
                        <label>Password</label>
                        <input type="password" name="password" class="form-control" required>
                     </div>
					 <div class="from-group">
                        <label>Confirm Password</label>
                        <input type="password" name="confirmPassword" class="form-control" required>
                     </div>
                     <div class="from-group">
                        <input type="submit" name="signup" value="Sign Up" class="btn btn-primary">
                    </div>
                </form>    
            </div>
        </div>
        </div>    
    </div>
</body>
</html>