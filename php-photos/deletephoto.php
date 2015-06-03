<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">

    <head>
        <title>Photo Gallery</title>
        <link rel="stylesheet" type="text/css" href="res/css/Site.css">
        <link href="res/lightbox/css/lightbox.css" rel="stylesheet" />
        <script src="res/lightbox/js/jquery-1.10.2.min.js"></script>
        <script src="res/lightbox/js/lightbox-2.6.min.js"></script>
    </head>

    <body>

        <div id="pageOuter">

            <h1>PHP - Photo Gallery</h1>

			<?php include 'dbaccess.php'; ?>
			<?php 
				$photoId = 0;
				$confirm = 0;

				$photoId = $_GET["oid"];
				$confirm = $_GET["confirm"];

				if ($photoId <= 0)
				{
					echo "No object ID provided.";
				}
				else
				{
				try {
						$pdo = new PDO('mysql:host='.constant("host").';dbname='.constant("dbname"), 
											constant("user"), constant("password"));
						$qryResult = $pdo->query('SELECT * FROM tbl_photos WHERE id = '.$photoId);
						
						for($i=0; $row = $qryResult->fetch(); $i++){
							
							$photoId = $row['id'];
							$description = $row['description'];
							$fileRef = $row['file_ref'];
							$title = $row['title'];
							
							if ($confirm != 1)
							{
								echo "<p>Are you sure you want to delete this?<p>
									<a href='res/photos/$fileRef' rel='lightbox' title='$description'>
										<img class='photo' src='res/photos/$fileRef' data-lightbox='image-$photoId' />
									</a>
									<a href='index.php'>Cancel</a>&nbsp;&nbsp;
									<a href='?confirm=1&oid=$photoId'>Delete</a>";
							}
							//TODO: write a delete query in php perhaps using the query->prepare() method.
							/*
							else
							{
								try
								{
									echo "DELETED " + RMySqlDbHelper.deletePhoto(photoId).intResult + "PHOTO.";
									echo "<p><a href='Default.aspx'>Back to Gallery<a></p>";
								}
								catch (Exception ex) { output.InnerHtml += "DELETE ERROR: "; }
							}
							*/
							
						}
						$pdo = null;
				} catch (PDOException $e) {
						print "Error!: " . $e->getMessage() . "<br/>";
						die();
				}
			?>
			
		</div>
		
	</body>
	
</html>