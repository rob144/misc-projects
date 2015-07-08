function Caro(boxElem){
    
    this.caroBox = $(boxElem);
    this.CARO_INFO = { 
        mousedown: false,
        callbacks: []
    };

    /* Add the container divs */
    if(!this.caroBox.find('.caro-window').length){
        this.caroBox.append(
            '<div class="caro-window"><div class="caro-stage"></div></div>'
        );
    }
    this.caroWindow = this.caroBox.find('.caro-window');
    this.caroStage = this.caroBox.find('.caro-stage');
    
    /* Add the nav controls */
    this.caroBox.prepend('<div class="caro-nav-btn caro-nav-next">Next</div>');
    this.caroBox.prepend('<div class="caro-nav-btn caro-nav-prev">Prev</div>');
}

Caro.prototype.resizeUi = function(forceScrollBar){
    //TODO: set the stage width big enough to contain all the slides
    //TODO: set the width of the slides to match caro window width
    //$caroStage.width($slides.width() * $slides.length + 10000);
    //$slides.width( $caroWindow.width() );
}

Caro.prototype.addSlide = function(slideHtml){
    this.caroStage.append("<div class='caro-item'>" + slideHtml + "</div>");
}

Caro.prototype.removeSlide = function(index){
    var caro = this;
    if(index >= 1 && caro.caroStage.find('.caro-item:nth-child(' + index + ')').length){
        caro.caroStage.find('.caro-item:nth-child(' + index + ')').remove();
    }
}

Caro.prototype.getLast = function(){
    return this.caroStage.find('.caro-item:last');
}

Caro.prototype.init = function(slideHtml){
    var caro = this;
    caro.caroStage.find('div').each(function(i, elem){
        $(elem).remove();
        caro.addSlide($(elem).html());
    });;
}