function Caro(boxElem){
    
    var caro = this;

    caro.name = boxElem;
    caro.caroBox = $(boxElem);
    caro.CARO_INFO = { 
        mousedown: false,
        callbacks: []
    };

    /* Add the container divs */
    if(!caro.caroBox.find('.caro-window').length){
        caro.caroBox.append(
            '<div class="caro-window"><div class="caro-stage"></div></div>'
        );
    }
    caro.caroWindow = caro.caroBox.find('.caro-window');
    caro.caroStage = caro.caroBox.find('.caro-stage');
    
    /* Add the nav controls */
    caro.caroBox.prepend('<div class="caro-nav-btn caro-nav-next">Next</div>');
    caro.caroBox.prepend('<div class="caro-nav-btn caro-nav-prev">Prev</div>');
}

Caro.prototype.resizeUi = function(forceScrollBar){
    
    var caro = this;
    var slides = caro.getSlides();
    var windowWidth = caro.caroWindow.width();

    //Make the stage width big enough to contain all the slides
    caro.caroStage.width(slides.length * caro.caroWindow.width());
    
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

Caro.prototype.getCurrentSlide = function(){
    
    var caro = this;
    var targetIndex;
    var minDiff = caro.caroStage.width();
    var slides = caro.getSlides();

    //Find the slide with the most area inside the caro window
    slides.each(function(index, elem){

        var slide = $(elem);
        var diffLeft = slide.offset().left - caro.caroWindow.offset().left;
        var diffRight = slide.offset().left + slide.width() 
                        - (caro.caroWindow.offset().left + caro.caroWindow.width());
        var diff = Math.abs(diffLeft) + Math.abs(diffRight);
        
        if(diff < minDiff){
            minDiff = diff;
            targetIndex = index;
        }

    });

    return slides.eq(targetIndex);
}

Caro.prototype.getSlide = function(slideIndex){
    return this.caroStage.find('.caro-item').eq(slideIndex);
}

Caro.prototype.getLast = function(){
    return this.caroStage.find('.caro-item:last');
}

Caro.prototype.nextSlide = function(){ 
    this.moveSlide(-1);
};

Caro.prototype.prevSlide = function(){
    this.moveSlide(1);
};

Caro.prototype.animateStage = function(newLeft){
    var caro = this;
    if(!caro.caroStage.hasClass('sliding')){
        caro.caroStage.addClass('sliding');
        caro.caroStage.animate(//TODO: animate margin rather than left position.
            { left: newLeft },
            300, 
            function(){ 
                caro.caroStage.removeClass('sliding');
                /*
                if(getCallback('animateStage') != null){
                    getCallback('animateStage')();
                }*/
            }
        );
    }
};

Caro.prototype.moveSlide = function(vector, onComplete){
    
    var caro = this;

    //Check if still moving
    if(caro.caroStage.hasClass('sliding')){
        return;
    }

    //Get the current slide.
    var currSlide = caro.getCurrentSlide();
    var operator = (vector < 0 ? '-=' : vector > 0 ? '+=' : '');

    //Check if the next or previous slide exists.
    if((vector < 0 && currSlide.next().length) 
        || (vector > 0 && currSlide.prev().length)){
        caro.animateStage( operator + caro.caroBox.find('.caro-item').outerWidth() );
    }
};

Caro.prototype.animateToSlide = function(targetSlide){
    var caro = this;
    if(targetSlide !== null){
        targetSlide = $(targetSlide);
        var newLeft = caro.caroStage.offset().left - targetSlide.offset().left;
        caro.animateStage(newLeft);
    }
};

Caro.prototype.init = function(slideHtml){
    
    var caro = this;
    
    caro.caroStage.find('div').each(function(i, elem){
        $(elem).remove();
        caro.addSlide($(elem).html());
        caro.resizeUi();
    });

    var resizeHandler = function(caroObj){
        clearTimeout(caroObj.timeOutId);
        caroObj.timeOutId = setTimeout(
            function(){ 
                caroObj.resizeUi(true); 
            }, 300 //Set delay to avoid many resize events.
        );
    }

    $(window).resize(function(){
        resizeHandler(caro);
    });

    caro.caroBox.find('.caro-nav-prev').click(
        function(){ caro.prevSlide(); }
    );
    caro.caroBox.find('.caro-nav-next').click(
        function(){ caro.nextSlide(); }
    );
}