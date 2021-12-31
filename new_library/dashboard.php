


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Dashboard</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>


    <style>

        .wrapper{
            width: 900px;
            margin: 0 auto;

        }
        table tr td:last-child{
            width: 120px;
        }


    </style>

    <script>
        $(document).ready(function (){
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</head>
<body>
<div class="wrapper">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="mt-5 mb-3 clearfix">
                    <h2 class="pull-left">Books Details</h2>
                    <a href="create.php" class="btn btn-success pull-right"><i class="fa fa-plus"></i> Add New Book</a>
                </div>

                <?php
                // Include config file
                require_once "config.php";

                // Attempt select query execution
                $sql = "SELECT * FROM book_final_exam";
                if($result = $mysqli->query($sql)){
                    if($result->num_rows > 0){
                        echo '<table class="table table-bordered table-striped">';
                        echo"<thead>";
                        echo"<tr>";
                        echo "<th>#</th>";
                        echo "<th>Author ID</th>";
                        echo "<th>Title</th>";
                        echo "<th>ISBN</th>";
                        echo "<th>Publish year</th>";
                        echo "<th>Available</th>";
                        echo "<th>Action</th>";
                        echo "</tr>";
                        echo "</thead>";
                        echo "<tbody>";
                        while($row = $result->fetch_array()){
                            echo "<tr>";
                            echo "<td>" . $row['bookid'] . "</td>";
                            echo "<td>" . $row['authorid'] . "</td>";
                            echo "<td>" . $row['title'] . "</td>";
                            echo "<td>" . $row['ISBN'] . "</td>";
                            echo "<td>" . $row['pub_year'] . "</td>";
                            echo "<td>" . $row['available'] . "</td>";

                            echo "<td>" ;
                            echo '<a href="read.php?bookid='. $row['bookid'] .'" class="mr-3"
                                title="View Record" data-toggle="tooltip"><span class="fa fa-eye"></span></a>';
                            echo '<a href="update.php?bookid='. $row['bookid'] .'" class="mr-3"
                                title="Update Record" data-toggle="tooltip"><span class="fa fa-pencil"></span></a>';
                            echo '<a href="delete.php?bookid='. $row['bookid'] .'" 
                                title="Delete Record" data-toggle="tooltip"><span class="fa fa-trash"></span></a>';
                            echo "</td>";
                            echo "</tr>";
                        }
                        echo "</tbody>";
                        echo "</table>";
                        //Free result set
                        $result->free();
                    }else{
                        echo '<div class="alert alert-danger"><em>No records were found.</em></div>';
                    }
                }else{
                    echo "Oops ! Something went wrong. Please try again later.";
                }

                // Close connection
                $mysqli->close();
                ?>
            </div>
        </div>
    </div>
    <p>
        <a href="logout.php" class="btn btn-danger ml-3">Sign out of Your Account</a>
    </p>
</div>
</body>
</html>
