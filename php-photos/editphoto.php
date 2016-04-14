<?php include 'dbaccess.php'; ?>
<?php 
	//Init variables with default values
    $content = "";
	$photoId = -1;
	$photoDesc = '';
	$fileRef = '';
	$photoTitle = '';
	
	if($_SERVER['REQUEST_METHOD'] === 'GET'){
		if(isset($_GET["photoId"])) $photoId = $_GET['photoId'];
	}
	
	if($_SERVER['REQUEST_METHOD'] === 'POST'){
		$photoId = $_POST['photoId'];
		$photoDesc = $_POST['photoDesc'];
		$fileRef = $_POST['fileRef'];
		$photoTitle = $_POST['photoTitle'];
	}
	
	//Create DB connection object
	try {
        $pdo = new PDO(
		    'mysql:host='.constant("host").';dbname='.constant("dbname"), 
            constant("user"), constant("password")
		);
	} catch (Exception $e) {
        echo 'Caught exception: ', $e->getMessage(), "\n";
    }
	
	//Get the photo record from the database
    if ($photoId > 0){
        
        try{
            $prep = $pdo->prepare("SELECT * FROM photos WHERE id = :id LIMIT 1");
            
            if (!$prep->execute(array(":id" => $photoId))) {
               $error = $prep->errorInfo();
               echo "Error: {$error[2]}"; // element 2 has the string text of the error
            } else {
                while ($row = $prep->fetch(PDO::FETCH_ASSOC)) { // check the documentation for the other options here
                    // do stuff, $row is an associative array, the keys are the field names                    
                    $photoId = $row['id'];
                    $photoDesc = $row['description'];
                    $fileRef = $row['file_ref'];
                    $photoTitle = $row['title'];    
                    break;
                }
            }
        } catch (Exception $e) {
            echo 'Caught exception: ',  $e->getMessage(), "\n";
        }
    }
    
	if($_SERVER['REQUEST_METHOD'] === 'POST'){
		//TODO: update the DB record
		if($photoID == -1) {
			$prep = $db->prepare("INSERT INTO photos (description,file_ref,title) VALUES (:p_desc, :p_file_ref, :p_title);");
			$prep->execute(array(":p_desc" => $photoDesc, ":p_file_ref" => $fileRef, ":p_title" => $photoTitle));
			$content = "<p>The photo has been created.</p>
			<p><a href='index.php'><< Back to home page</a></p>
			";
		} else {
			$prep = $db->prepare("UPDATE photos SET description = :p_desc, file_ref = :p_file_ref, title = :p_title");
			$prep->execute(array(":p_desc" => $photoDesc, ":p_file_ref" => $fileRef, ":p_title" => $photoTitle));
			$content = "<p>The photo has been updated.</p>
			<p><a href='index.php'><< Back to home page</a></p>
			";
		}
	}
	else{
		//Display edit controls
		$content = "
			<form id='saveEdit' action='deletephoto.php' method='post'>
				<h3>Create/Edit Photo</h3>
				<div class='editPhotoFrame' >
					<a href='res/photos/$fileRef' rel='lightbox' title='$photoDesc'>
						<img class='photo' src='res/photos/$fileRef' data-lightbox='image-$photoId' />
					</a>
				</div>
				<div class='editPhotoFields'>
					<input type='hidden' name='fileRef' value='$fileRef' />
					<input type='file' name='photoFile'/>
					
					<div class='divRow'>
						<div class='divRowLeft'>
							<label for='inpPhotoTile'>Title: </label>
						</div>
						<div class='divRowRight'>
							<input id='inpPhotoTitle' name='photoTitle' type='text' value='$photoTitle' /> 
						</div>
					</div>
				
					<div class='divRow'>
						<div class='divRowLeft'>
							<label for='inpPhotoDesc'>Description: </label>
						</div>
						<div class='divRowRight'>
							<input id='inpPhotoDesc' name='photoDesc' type='text' value='$photoDesc' />
						</div>
					</div>
				
					<div id='divEditSaveCancel'>
						<a id='cancelEdit' href='index.php'>Cancel</a>
						<input type='hidden' name='photoId' value='$photoId' /> 
						<input class='btnSave' type='submit' name='save' value='Save' /> 
					</div>
				</div>
			</form>
			";
	}

    //Print the HTML
    echo "
        <html>
            <head>
                <title>Photos</title>
                <link rel='stylesheet type='text/css' href='res/css/site.css'>
            </head>
            <body>
                <div class='pageOuter'>
                    <h1>Photo App</h1>
                    <div id='containerPhotos'>
                       $content
                    </div>
                </div>
            </body>
        </html>
    ";
?>