#!/usr/bin/perl

use CGI::Carp qw(fatalsToBrowser);
use DBI;

print "Content-type: text/html\n\n";

$db = DBI->connect('dbi:mysql:photogallery1','root','GiaaHlm4e')
   or die "Connection Error: $DBI::errstr\n";
$qPhotos = $db->prepare("SELECT id, title, description, file_ref FROM photos");
$qPhotos->execute 
   or die "SQL Error: $DBI::errstr\n";

my ($photoId, $photoTitle, $photoDesc, $photoFile);
$qPhotos->bind_col(1, \$photoId);
$qPhotos->bind_col(2, \$photoTitle);
$qPhotos->bind_col(3, \$photoDesc);
$qPhotos->bind_col(4, \$photoFile);

my $photosHtml = "";
my $i = 0;

while ($qPhotos->fetch) {
    
    my $cssClass = ($i > 0 && ($i + 1) % 4 == 0 ? "photoOuterRowEnd" : "photoOuter");

    $photosHtml .= qq{
    <div class='$cssClass'>
        <div class='photoInner'>
	    <a href='res/photos/$photoFile' rel='lightbox' title='$photoTitle'>
            <img class='photo' src='res/photos/$photoFile' data-lightbox='image-$photoId' />
	    </a>
	    <div class='photoControls'>
		<a class='photoControl' href='res/photos/$photoFile' rel='lightbox' class='photoControl' title='$photoDesc' >
		<img class='photoControlIcon' src='res/ui/view.png' />
	        </a>
                <a class='photoControl' title='edit photo' href='?action=editphoto&oid=$photoId'>
                    <form action='editphoto.pl' method='post'>
                        <input class='editPhoto' type='submit' name='edit:$photoId' value='' /> 
                    </form>
                </a>
                <a class='photoControl' title='download photo' href='?action=downloadphoto&oid=$photoId'>
                    <img class='photoControlIcon' src='res/ui/download.png' />
                </a>
                <a class='photoControl'>
                    <form action='deletephoto.pl' method='post'>
                        <input class='deletePhoto' type='submit' name='delete:$photoId' value='' /> 
                    </form>
                </a>               
             </div>
        </div>
    </div>
    };
    $i++;
}

$html = qq{
    
    <html>
        <head>
            <title>Photos</title>
            <link rel="stylesheet" type="text/css" href="res/css/site.css">
        </head>
        <body>
            <div class="pageOuter">
                <h1>Photo App (Perl)</h1>
                <div id="containerPhotos">
                    $photosHtml
                </div>
            </div>
        </body>
    </html>

};

print $html;
