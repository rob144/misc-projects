#!/usr/bin/perl

use warnings;
use CGI::Carp qw(fatalsToBrowser);
use CGI qw(:standard);
use DBI;

print "Content-type: text/html\n\n";

$photoId = 0;
$confirm = 0;

#Get the photo ID and 'confirm' value from the posted param name
for $paramName (param()) {
    if (index($paramName, "edit") eq 0) {
        my @parts = split(/:/,$paramName);
        $photoId = $parts[1];
    }
    if (index($paramName, "confirmedit") eq 0) {
        @parts = split(/:/,$paramName);
        $confirm = $parts[1];
    }
}

#If no photo ID then redirect back to home.
if ($photoId <= 0) {
    print redirect(-url => 'home.pl');
}

#Get the photo record from the database
$db = DBI->connect('dbi:mysql:photogallery1','root','GiaaHlm4e')
   or die "Connection Error: $DBI::errstr\n";
$sql = "SELECT id, title, description, file_ref FROM photos WHERE id = ? LIMIT 1";
my ($photoId, $photoTitle, $photoDesc, $photoFile) 
    = $db->selectrow_array($sql, undef, ($photoId));

my $content = "";

if ($photoId <= 0){
    $content = qq{
        <p>"Photo not found"</p>
        <p><a href='home.pl'><< Back to home page</a></p>
    };
}
else {
    if($confirm == 1){
        #Delete the record from the DB
        #$qDelete = $db->prepare("DELETE FROM photos WHERE id = ?");
        #$qDelete->execute($photoId)
        #    or die "SQL Error: $DBI::errstr\n";
        $content = qq{
            <p>The photo has been updated.</p>
            <p><a href='home.pl'><< Back to home page</a></p>
        };
    }
    else{
        #Display edit controls
        $content = qq{
            <p>Edit Photo<p>
            <a href='res/photos/$photoFile' rel='lightbox' title='$photoDesc'>
                <img class='photo' src='res/photos/$photoFile' data-lightbox='image-$photoId' />
            </a>

            <div class='divRow'>
                <div class='divRowLeft'>
                    <label for='inpPhotoTile'>Title: </label>
                </div>
                <div class='divRowRight'>
                    <input id='inpPhotoTitle' name='inpPhotoTitle' type='text' /> 
                </div>
            </div>
            <div class='divRow'>
                <div class='divRowLeft'>
                    <label for='inpPhotoDesc'>Description: </label>
                </div>
                <div class='divRowRight'>
                    <input id='inpPhotoDesc' name='inpPhotoDesc' type='text' />
                </div>
            </div>
            
            <div id='divEditSaveCancel'>
                <a id='cancelEdit' href='home.pl'>Cancel</a>
                <form id='saveEdit' action='deletephoto.pl' method='post'>
                    <input type='hidden' name='edit:$photoId' value='$photoId' /> 
                    <input class='btnSave' type='submit' name='confirmedit:1' value='Save' /> 
                </form>
            </div>
        };
    }
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
                   $content
                </div>
            </div>
        </body>
    </html>

};

print $html;
