
<?php
// Include config file
require_once "config.php";

$authorid = $title = $ISBN = $pub_year = $available = "";
$authorid_err = $title_err = $ISBN_err = $pub_year_err = $available_err = "";

// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"]== "POST"){
    //Validate Book ID
    if(empty(trim($_POST["authorid"]))){
        $authorid_err = "Please enter Author ID.";
    }elseif (!preg_match('/^[0-9]+$/', trim($_POST["authorid"]))){
        $authorid_err = " Book ID just contains only numbers.";
    }
    else{
        $sql = "select bookid from book_final_exam where authorid=?";

        if($stmt = $mysqli->prepare($sql)){
            $stmt->bind_param("s",$param_authorid);

            $param_authorid = trim($_POST["authorid"]);

            if($stmt->execute()){
                $stmt->store_result();

                if($stmt->num_rows ==1){
                    $authorid_err = "This author ID is already taken.";
                }else{
                    $authorid = trim($_POST["authorid"]);
                }
            }else {
                echo "Oops! Something went wrong. Please try again later.";
            }
            $stmt->close();
        }
    }

    // Validate book name
    $input_title = trim($_POST["title"]);
    if(empty($input_title)){
        $title_err = "Please enter Book title.";

    }else{
        $title = $input_title;
    }

    // Validate author name
    $input_ISBN = trim($_POST["ISBN"]);
    if(empty($input_ISBN)){
        $ISBN_err = "Please enter Author name.";

    }else{
        $ISBN = $input_ISBN;
    }

    // Validate year
    $input_pub_year = trim($_POST["pub_year"]);
    if(empty($input_pub_year)){
        $pub_year_err = "Please enter the published year.";
    }elseif (!preg_match('/^[0-9]+$/', trim($_POST["pub_year"]))){
        $pub_year_err = " Please enter an integer type.";
    }
    elseif($input_pub_year < 0 || $input_pub_year > 2021){
        $namxb_err="Published time is invalid.";
    }else {
        $pub_year = $input_pub_year;
    }

    // Validate book status
    $input_available = trim($_POST["available"]);
    if(empty($input_available)){
        $available_err = "Please enter Book status.";
    } else{
        $available = $input_available;
    }




    //Check input errors before inserting in database
    if(empty($authorid_err) && empty($title_err) && empty($ISBN_err) && empty($pub_year_err) && empty($available_err)  ){
        //Prepare an insert statement
        $sql = "insert into book_final_exam (authorid, title, ISBN, pub_year, available) values (?,?,?,?,?)";

        if($stmt = $mysqli->prepare($sql)){
            //Bind variables to the prepared statement as parameters
            $stmt->bind_param("sssss",$param_authorid, $param_title, $param_ISBN, $param_pub_year, $param_avalable);

            //Set parameters
            $param_authorid = $authorid;
            $param_title = $title;
            $param_ISBN = $ISBN;
            $param_pub_year = $pub_year;
            $param_avalable = $available;

            // Attempt to execute the prepared statement
            if($stmt->execute()){
                //Records created successfully. Redirect to landing page
                header("location: dashboard.php");
                exit();
            }else{
                echo "Oops! Something went wrong. Please try again later.";
            }
        }
        // Close statement
        $stmt->close();
    }
    //Close connection
    $mysqli->close();
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Create Record</title>
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
                <h2 class="mt-5">Create Book</h2>
                <p> Please fill this form and submit to add Book record to the database.</p>
                <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post">
                    <div class="form-group">
                        <label>Book ID</label>
                        <input type="text" name="ISBN" class="form-control
                                <?php echo (!empty($ISBN_err)) ? 'is-invalid' : ''; ?>" value="<?php echo $ISBN; ?>">
                        <span class="invalid-feedback"><?php echo $ISBN_err; ?></span>
                    </div>
                    <div class="form-group">
                        <label>Author ID</label>
                        <input type="text" name="authorid" class="form-control
                                <?php echo (!empty($authorid_err)) ? 'is-invalid' : ''; ?>" value="<?php echo $authorid; ?>">
                        <span class="invalid-feedback"><?php echo $authorid_err; ?></span>
                    </div>
                    <div class="form-group">
                        <label>Book Name</label>
                        <input type="text" name="title" class="form-control
                                <?php echo (!empty($title_err)) ? 'is-invalid' : ''; ?>" value="<?php echo $title; ?>">
                        <span class="invalid-feedback"><?php echo $title_err; ?></span>
                    </div>

                    <div class="form-group">
                        <label>Publish year</label>
                        <input type="text" name="pub_year" class="form-control
                             <?php echo(!empty($pub_year_err)) ? 'is-invalid' : ''; ?>" value="<?php echo $pub_year;  ?>">
                        <span class="invalid-feedback"><?php echo $pub_year_err; ?></span>
                    </div>
                    <div class="form-group">
                        <label>Available</label>
                        <input type="text" name="available" class="form-control
                                <?php echo (!empty($available_err)) ? 'is-invalid' : ''; ?>" value="<?php echo $available; ?>">
                        <span class="invalid-feedback"><?php echo $available_err; ?></span>
                    </div>
                    <input type="submit" class="btn btn-primary" value="Submit">
                    <a href="dashboard.php" class="btn btn-secondary ml-2">Cancel</a>
                </form>
            </div>
        </div>
    </div>
</div>
</body>
</html>
