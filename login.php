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
                <form action validation="validation.php" method="post">
                    <div class="from-group">
                        <label>Username</label>
                        <input type="text" name="user" class="form-control" required>
                    </div>
                    <div class="from-group">
                        <label>Password</label>
                        <input type="password" name="password" class="form-control" required>
                     </div>
                    <button type="submit" class="btn btn-primary"> Login </button>
                </form>    
            </div>
            <div class ="col-md-6 login-right">
                <h2> Sign-Up Here </h2>
                <form action validation="signup.php" method="post">
                    <div class="from-group">
                        <label>Username</label>
                        <input type="text" name="user" class="form-control" required>
                    </div>
                    <div class="from-group">
                        <label>Password</label>
                        <input type="password" name="password" class="form-control" required>
                     </div>
                    <button type="submit" class="btn btn-primary"> Sign-Up </button>
                </form>    
            </div>
        </div>
        </div>    
    </div>
</body>


</html>