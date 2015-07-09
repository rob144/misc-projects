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
    
    var caro = this;
    var slides = caro.getSlides();
    var windowWidth = caro.caroWindow.width();

    //Make the stage width big enough to contain all the slides
    this.caroStage.width(slides.length * caro.caroWindow.width());
    
    //Aet the width of the slides to match caro window width
    //I.e. show one slide in the caro window
    slides.width(windowWidth);
}

Caro.prototype.getSlides = function(){
    return this.caroStage.find('.caro-item');
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
        caro.resizeUi();
    });
    $(window).resize(function(){//TODO: fix this to work with multiple caro instances
        clearTimeout(this.id);
        this.id = setTimeout(function(){ caro.resizeUi(true); }, 300);
    })
}