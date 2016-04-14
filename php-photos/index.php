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
            <a href="editphoto.php" >Add Photo</a>
            
            <form id="frmFileUpload">
                <input id="inpFileUpload" name="inpFileUpload" type="file" />
                <button>Save</button>
            </form>

            <div id="containerPhotos">
                <?php include 'dbaccess.php'; ?>
                <?php
                    try {
                        $pdo = new PDO('mysql:host='.constant("host").';dbname='.constant("dbname"), 
                                            constant("user"), constant("password"));
                        $qryResult = $pdo->query('SELECT * from photos');
                        
                        for($i=0; $row = $qryResult->fetch(); $i++){
                            
                            $photoId = $row['id'];
                            $description = $row['description'];
                            $fileRef = $row['file_ref'];
                            $title = $row['title'];
                            
                            $cssClass = ($i > 0 && ($i + 1) % 4 == 0 ? "photoOuterRowEnd" : "photoOuter");
                            
                            echo "
                                <div class='$cssClass'>
                                    <div class='photoInner'>
                                        <a href='res/photos/$fileRef' rel='lightbox' title='$title'>
                                            <img class='photo' src='res/photos/$fileRef' data-lightbox='image-$photoId' />
                                        </a>
                                        <div class='photoControls'>
                                            <a href='res/photos/$fileRef' rel='lightbox' class='photoControl' title='$description
                                                <img class='photoControlIcon' src='res/ui/view.png' />
                                            </a>
                                            <a class='photoControl' title='edit photo' href='editphoto.php?photoId=$photoId'>
                                                <img class='photoControlIcon' src='res/ui/edit.png' />
                                            </a>
                                            <a class='photoControl' title='download photo' href='getphoto.php?photoId=$photoId'>
                                                <img class='photoControlIcon' src='res/ui/download.png' />
                                            </a>
                                            <a class='photoControl' title='delete photo' href='deletephoto.php?photoId=$photoId&confirm=0'>
                                                <img class='photoControlIcon' src='res/ui/delete.png' />
                                            </a>
                                        </div>
                                    </div>
                                </div>";
                        }
                        $pdo = null;
                    } catch (PDOException $e) {
                        print "Error!: " . $e->getMessage() . "<br/>";
                        die();
                    }
                ?>
            </div>

        </div>
        
        <div id="pageFooter">
            <p>Site designed and developed by Robin Dunn.</p>
            <p><?php echo 'Server running PHP version: ' . phpversion(); ?></p>
        </div>

    </body>

</html>