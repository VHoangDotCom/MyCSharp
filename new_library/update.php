
<?php
// Include config file
require_once "config.php";

//Define variables and initialize with empty values
  $title = $ISBN = $pub_year = $available =  "";
 $title_err = $ISBN_err = $pub_year_err = $available_err =  "";

// Processing form data when form is submitted
if(isset($_POST["bookid"]) && !empty($_POST["bookid"])){
    // Get hidden input value
    $bookid = $_POST["bookid"];





    //Validate name
    $input_title = trim($_POST["title"]);
    if(empty($input_title)){
        $title_err = "Please enter a book name.";
    }elseif(!filter_var($input_title, FILTER_VALIDATE_REGEXP, array("options"=>array("regexp"=>"/^[a-zA-Z0-9\s]+$/")))){
        $title_err = "Please enter a valid name.";
    }else{
        $title = $input_title;
    }
    //Validate author
    $input_ISBN = trim($_POST["ISBN"]);
    if(empty($input_tacgia)){
        $ISBN_err = "Please enter an ISBN .";
    }else{
        $ISBN = $input_ISBN;
    }

    //Validate year
    $input_pub_year = trim($_POST["pub_year"]);
    if(empty($input_pub_year)){
        $pub_year_err = "Please enter the publish year.";
    }elseif(!ctype_digit($input_pub_year)){
        $pub_year_err = "Please enter a positive integer value.";
    }else{
        $pub_year = $input_pub_year;
    }

    // Validate book status
    $input_available = trim($_POST["available"]);
    if(empty($input_available)){
        $available_err = "Please enter Book status.";
    }
    else{
        $available = $input_available;
    }

    //Check input errors before inserting in database
    if(empty($title_err) && empty($ISBN_err) && empty($pub_year_err) && empty($available_err) ){
        //Prepare an update statement
        $sql = "update book_final_exam set title = ? , ISBN=?, pub_year=? , available=?  where bookid=?";

        if($stmt = $mysqli->prepare($sql)){
            //Bind variables to the prepared statement as parameters
            $stmt->bind_param("ssssi",$param_title, $param_ISBN, $param_pub_year, $param_available,  $param_bookid);

            //Set parameters
            $param_title = $title;
            $param_ISBN = $ISBN;
            $param_pub_year = $pub_year;
            $param_available = $available;

            $param_bookid = $bookid;

            //Attempt to execute the prepared statement
            if($stmt->execute()){
                //Records updated successfully. Redirect to landing page
                header("location: dashboard.php");
                exit();
            }else{
                echo "Oops! Something went wrong. Please try again later.";
            }
        }

        //Close statement
        $stmt->close();
    }
    //Close connection
    $mysqli->close();
}else{
    //Check existence of id parameter before processing further
    if(isset($_GET["bookid"]) && !empty(trim($_GET["bookid"]))){
        //Get URL parameter
        $bookid = trim($_GET["bookid"]);

        //Prepare a select statement
        $sql = "SELECT * from book_final_exam where bookid=?";
        if($stmt = $mysqli->prepare($sql)){
            //Bind variables to the prepared statement as parameters
            $stmt->bind_param("i",$param_id);

            //Set parameters
            $param_id = $bookid;

            //Attempt to execute the prepare statement
            if($stmt->execute()){
                $result = $stmt->get_result();
                if($result->num_rows == 1){
                    /* Fetch result row as an associative array. Since the result set
                    contains only one row, we don't need to use while loop */
                    $row = $result->fetch_array(MYSQLI_ASSOC);

                    //Retrieve individual field value
                    $title = $row["title"];
                    $ISBN = $row["ISBN"];
                    $pub_year = $row["pub_year"];
                    $available = $row["available"];

                }else{
                    //URL doesn't contain valid id. Redirect to error page
                    header("location: error.php");
                    exit();
                }
            }else{
                echo "Oops! Something went wrong. Please try again later.";
            }
        }

        //Close statement
        $stmt->close();

        //Close connection
        $mysqli->close();
    }else{
        //URL doesn't contain id parameter. Redirect to error page
        header("location: error.php");
        exit();
    }
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Update Record</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        .wrapper{
            width: 600px;
            margin: 0 auto;
        }
    </style>
</head>
<body>
<div class="wrapper">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2 class="mt-5">Update Book</h2>
                <p>Please edit the input values and submit to update the book record.</p>
                <form action="<?php echo htmlspecialchars(basename($_SERVER['REQUEST_URI'])); ?>" method="post">
                    <div class="form-group">
                        <label>Book Name</label>
                        <input type="text" name="title" class="form-control
                                 <?php echo (!empty($title_err)) ?'is-invalid' : ''; ?>" value="<?php echo $title; ?>">
                        <span class="invalid-feedback"><?php echo $title_err; ?></span>
                    </div>
                    <div class="form-group">
                        <label>ISBN</label>
                        <input type="text" name="ISBN" class="form-control
                                 <?php echo (!empty($ISBN_err)) ?'is-invalid' : ''; ?>" value="<?php echo $ISBN; ?>">
                        <span class="invalid-feedback"><?php echo $ISBN_err; ?></span>
                    </div>
                    <div class="form-group">
                        <label>Published year</label>
                        <input type="text" name="pub_year" class="form-control
                                 <?php echo (!empty($pub_year_err)) ?'is-invalid' : ''; ?>" value="<?php echo $pub_year; ?>">
                        <span class="invalid-feedback"><?php echo $pub_year_err; ?></span>
                    </div>
                    <div class="form-group">
                        <label>Available</label>
                        <input type="text" name="available" class="form-control
                                 <?php echo (!empty($available_err)) ?'is-invalid' : ''; ?>" value="<?php echo $available; ?>">
                        <span class="invalid-feedback"><?php echo $available_err; ?></span>
                    </div>

                    <input type="hidden" name="bookid" value="<?php echo $bookid; ?>" />
                    <input type="submit" class="btn btn-primary" value="Submit">
                    <a href="dashboard.php" class="btn btn-secondary ml-2">Cancel</a>
                </form>
            </div>
        </div>
    </div>
</div>
</body>
</html>
