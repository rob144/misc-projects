var GRID_SQUARE_SIZE = 20;
var SNAPPING = false;
var TOOL_SELECTED = "";

var WebDraw = {};
var geometry = [];
var geometryOther = [];
var canvas;
var context;

WebDraw.types = function(){
	this.point = "POINT";
	this.circle = "CIRCLE";
	this.line = "LINE";
	this.rect = "RECTANGLE";
}

var objTypes = new WebDraw.types();

var lineTool = {};
lineTool.started = false;
lineTool.x1 = 0;
lineTool.y1 = 0;
lineTool.x2 = 0;
lineTool.y2 = 0;

var circleTool = {};
circleTool.started = false;
circleTool.x = 0;
circleTool.y = 0;
circleTool.r = 0;

var rectTool = {};
rectTool.started = false;
rectTool.x1 = 0;
rectTool.y1 = 0;
rectTool.x2 = 0;
rectTool.y2 = 0;

function line(x1,y1,x2,y2)
{
	this.type = objTypes.line;
	this.x1=x1;
	this.y1=y1;
	this.x2=x2;
	this.y2=y2;
	this.toString = function(){ 
		return "LINE (" + x1 + "," + y1 +")" + "(" + x2 + "," + y2 + ")"; };
}

function circle(x,y,r,fill)
{
	this.type = objTypes.circle;
	this.x = x;	
	this.y = y;
	this.r = r;
	this.fill = fill;
	this.colour = "";
	this.toString = function(){ 
		return "CIRCLE (" + x + "," + y + "," + r + ","+fill+")"; };
}

function rect(x1,y1,x2,y2,fill){
	this.type = objTypes.rect;
	this.x1=x1;
	this.y1=y1;
	this.x2=x2;
	this.y2=y2;
	this.fill = fill;
}

$(document).ready(function(){
	
	$("#ckbxShowGrid").attr('checked', false);
	$("#ckbxSnapGrid").attr('checked', false);
					
	canvas = document.getElementById("canvas1");
	context = canvas.getContext("2d");
	context.translate(0, canvas.height);
	context.scale(1,-1);
	canvas.addEventListener('mousemove', onCanvasMouseMove, false);
	canvas.addEventListener('click', onCanvasClick, false);

	/* 
		http://api.jquery.com/category/selectors/
		http://api.jquery.com/child-selector/
		TODO: set up click events for menu children.
	*/

	/*
	$("#miFile").click( function(){ 
		
		if($("#mPopup").is(":visible")){
			$("#mPopup").remove();
		}else{
			var popup = $('<div/>', {
				id: 'mPopup',
				title: 'file menu',
				text: 'File menu'
			}).appendTo($("#theBody"));
			
			popup.css({
					position:'absolute', 
					left: $(this).position().left, 
					top: $(this).position().top + $(this).height(),
					zindex: 10,
					backgroundColor: 'yellow',
					border:'1px solid grey',
					padding:'5px'
				}
			);
		}
	});
	*/
	
	$("#miFile").click( function(){ 
		var obj = $("#miFile ul");
		if(obj.css("display") == "block"){
			obj.css("display","none");
		}
		else{
			obj.css("display","block");
		};
		
	});
	
	$("#miEdit").click( function(){  
		//TODO: show edit menu
	});
	
	$("#miView").click( function(){ 
		//TODO: show view menu
	});
	
	$("#canvas1").mouseleave(drawAll);						
	
	function toggleToolSelected(tool){
		
		var tools = ["pointerTool",
					"rectTool",
					"pointTool",
					"lineTool",
					"circleTool"];
					
		for(var i=0;i<tools.length;i++){
			if($(tool).attr('id')== tools[i]){
				$(tool).css("background-color","#7FC9FF");
				$(tool).unbind('mouseenter mouseleave');
			}else{
				$("#"+tools[i]).css("background-color","#fff")
				$("#"+tools[i]).hover(
					function(){$(this).css("background-color","#7FC9FF")},
					function(){$(this).css("background-color","#fff")}
				);
			}
		}
	}
	
	$("#toolBox").draggable(
		{ containment: '#theBody',
		scroll: false,
		handle: "#toolBoxTop" }
	);
	
	$("#ckbxShowGrid").click(
		function(event){ drawAll(); }				
	);
	
	$("#ckbxSnapGrid").click(
		function(event){
			if($("#ckbxSnapGrid").is(':checked')){
				SNAPPING = true;
			}else{
				SNAPPING = false;
			}
		}
	);
	
	$("#pointerTool").click(
		function(event){ 
			TOOL_SELECTED = "pointerTool";
			toggleToolSelected(this);
		}				
	);

	$("#rectTool").click(
		function(event){ 
			TOOL_SELECTED = "drawRectTool";
			toggleToolSelected(this);
		}				
	);
	
	$("#pointTool").click(
		function(event){ 
			TOOL_SELECTED = "drawPointTool";
			toggleToolSelected(this);
		}				
	);
	
	$("#lineTool").click(
		function(event){ 
			TOOL_SELECTED = "drawLineTool";
			toggleToolSelected(this);
		}				
	);
	
	$("#circleTool").click(
		function(event){ 
			TOOL_SELECTED = "drawCircleTool";
			toggleToolSelected(this);
		}				
	);

});

function setXY(ev){
	var rect = canvas.getBoundingClientRect();		
	xPos = ev.clientX - Math.ceil(rect.left);
	yPos = canvas.height - (ev.clientY - Math.ceil(rect.top));
	return {x:xPos, y:yPos};
}

function calcSnapCoord(wholes, remainder, bound){
	var snapTo = 0;
	if(remainder > bound){
		snapTo = wholes *  GRID_SQUARE_SIZE + GRID_SQUARE_SIZE;
	}else{
		snapTo = wholes *  GRID_SQUARE_SIZE;
	}
	return snapTo;
}

function getSnapPoint(mPos){
	
	//find nearest snap point
	var wholes;
	var remainder;
	var bound = GRID_SQUARE_SIZE / 2;
	var result = {x:0, y:0}
		
	wholes = Math.floor(mPos.x / GRID_SQUARE_SIZE);
	remainder = mPos.x - wholes *  GRID_SQUARE_SIZE;
	result.x = calcSnapCoord(wholes, remainder, bound);
		
	wholes = Math.floor(mPos.y / GRID_SQUARE_SIZE);
	remainder = mPos.y - wholes * GRID_SQUARE_SIZE;
	result.y = calcSnapCoord(wholes, remainder, bound);
	
	return result;				
}

function onCanvasMouseMove (ev) {

	var pos = {x:0 , y:0};
	pos = setXY(ev);

	drawAll();

	if(SNAPPING){
		//Draw cursor at snapping position
		pos = getSnapPoint(pos);
		drawRect( {x1:pos.x-6, y1:pos.y-6, x2:pos.x+6, y2: pos.y+6} );
		drawLine( {x1:pos.x-6, y1:pos.y, x2:pos.x+6, y2: pos.y} );
		drawLine( {x1:pos.x, y1:pos.y-6, x2:pos.x, y2: pos.y+6} );
	}
	
	if(lineTool.started == true){
		lineTool.x2 = pos.x;
		lineTool.y2 = pos.y;
		drawLine({x1:lineTool.x1, y1:lineTool.y1, 
					x2:lineTool.x2, y2:lineTool.y2});
	}
	
	if(circleTool.started == true){
		var b = pos.y - circleTool.y;
		var a = pos.x - circleTool.x;
		if (b == 0 && Math.abs(a) > 0) circleTool.r = Math.abs(a);
		if (a == 0 && Math.abs(b) > 0) circleTool.r = Math.abs(b);
		if (Math.abs(a) > 0 && Math.abs(b) > 0) 
			circleTool.r = Math.sqrt(Math.pow(a,2) + Math.pow(b,2)); 
		if (a == 0 && b == 0) circleTool.r = 0;
		if (circleTool.r > 0) 
			drawCircle({x:circleTool.x, y:circleTool.y, 
						r:circleTool.r, fill:false});
	}
	
	if(rectTool.started == true){
		rectTool.x2 = pos.x;
		rectTool.y2 = pos.y;
		drawRect({x1:rectTool.x1, y1:rectTool.y1, 
					x2:rectTool.x2, y2:rectTool.y2});
	}
	
	$("#mousePosition").text("" + pos.x + ", " + pos.y);
}

function onCanvasClick (ev) {
	
	var pos = {x:0 , y:0};
	
	pos = setXY(ev);
	if(SNAPPING) pos = getSnapPoint(pos);	
	
	if(TOOL_SELECTED == "drawPointTool"){
		//Draw a small circle to represent point
		geometry.push(new circle(pos.x,pos.y,4,true),false);
		drawCircle(pos.x,pos.y,4,true);
	}
	
	if(TOOL_SELECTED == "drawLineTool"){
		if(lineTool.started == true){
			lineTool.x2 = pos.x;
			lineTool.y2 = pos.y;
			var l = new line(lineTool.x1,lineTool.y1,lineTool.x2,lineTool.y2);
			drawLine(l);
			geometry.push(l);
			lineTool.started = false;
		}else{//If not started, save start position
			lineTool.x1 = pos.x;
			lineTool.y1 = pos.y;
			lineTool.started = true;
		}
	}
	
	if(TOOL_SELECTED == "drawCircleTool"){
		if(circleTool.started == true){
			var c = new circle(circleTool.x, circleTool.y, circleTool.r, false);
			drawCircle({x:c.x, y:c.y, r:c.r, fill:c.fill});
			geometry.push(c);
			circleTool.started = false;
		}else{//If not started, save start position
			circleTool.x = pos.x;
			circleTool.y = pos.y;
			circleTool.r = 0;
			circleTool.started = true;
		}
	}
	
	if(TOOL_SELECTED == "drawRectTool"){

		if(rectTool.started == true){
			var r = new rect(rectTool.x1,rectTool.y1,
							rectTool.x2,rectTool.y2,false);
			drawRect(r);
			geometry.push(r);
			rectTool.started = false;
		}else{//If not started, save start position
			rectTool.x1 = pos.x;
			rectTool.y1 = pos.y;
			rectTool.x2 = pos.x;
			rectTool.y2 = pos.y;
			rectTool.started = true;
		}
	}
	
	if(TOOL_SELECTED == "pointerTool"){
	
		//Highlight the nearest point
		
		var indexClosest = -1;
		var distClosest = 1000000;
		
		for(var i=0;i<geometry.length;i++){
			switch(geometry[i].type){
				case objTypes.line:
					//TODO: Is the line near to the pointer?
					break;
					
				case objTypes.circle:
					//Is the circle near to the pointer?
					var x2 = geometry[i].x;
					var y2 = geometry[i].y;
					var dist = Math.sqrt( Math.pow((x2 - pos.x), 2) 
										+ Math.pow((y2 - pos.y), 2) );
					if( dist < distClosest) {
						indexClosest = i;
						distClosest = dist;
					}
					break;
					
				case objTypes.rect:
					//TODO: Is the rectangle near to the pointer?
					break;
					
				default:break;
			}
		}
		
		//Highlight the point
		if(geometryOther.length >= 1) geometryOther.splice(0, 1);
		var c = new circle(geometry[indexClosest].x, geometry[indexClosest].y,
							geometry[indexClosest].r, true);
		c.colour = "red";
		geometryOther.push(c);
		
		//Is the point just a point or part of a line or shape?
		/* Check if any lines within selection distance */
		/*
		for(var i=0;i<geometry.length;i++){
			if(geometry[i].type == objTypes.line){
				//Work out the equation of the line
				//Work out the equation of the tangent to the mouse point
				//Set the equations equal to each other to find the closet point on the line
				//If its within a threshold highlight the line
			}
		}*/
	}
}

/***************************************************************
 DRAWING FUNCTIONS 
 ***************************************************************/

function drawGrid(){

	/*Grid square size*/
	var s = GRID_SQUARE_SIZE;

	context.beginPath();
	context.lineWidth = 0.5;
	context.strokeStyle = "blue";
	
	/*loop to create grid lines*/
	var i = 0;
	while (i<canvas.width){
		context.moveTo(i*s+s, 0);
		context.lineTo(i*s+s, canvas.height);
		i++;
	}
	
	var i = 0;
	while (i<canvas.height){
		context.moveTo(0, i*s+s);
		context.lineTo(canvas.width, i*s+s);
		i++;
	}

	context.stroke();
	context.closePath();
}

function drawLine( obj ){
	context.beginPath();
	context.lineWidth = 1;
	context.strokeStyle = "black";
	context.moveTo(obj.x1, obj.y1);
	context.lineTo(obj.x2, obj.y2);
	context.stroke();
	context.closePath();
}

function drawCircle( obj ){
	
	context.beginPath();
	context.lineWidth = 1;
	context.strokeStyle = "black";
	context.arc(obj.x, obj.y, obj.r, 0, Math.PI*2, false); 
	
	if((""+obj.fill).toUpperCase()=="TRUE"){
		if(""+obj.colour != ""){
			context.fillStyle = obj.colour;
		}else{
			context.fillStyle = 'green';
		}
		context.fill();
	}
	context.stroke();
	context.closePath();
}

function drawRect( obj ){
	canvas = document.getElementById("canvas1");
	context = canvas.getContext("2d");
	context.lineWidth = 1;
	context.strokeStyle = "blue";
	context.beginPath();
	context.strokeRect( obj.x1, obj.y1, 
						obj.x2-obj.x1, obj.y2-obj.y1 ); 
	context.closePath();
	context.stroke();
}

function drawAll(){
	
	clearCanvas();
	
	if($("#ckbxShowGrid:checked").val() != undefined ){
		drawGrid();
	}
	
	for(var i=0;i<geometry.length;i++){
		switch(geometry[i].type)
		{
			case objTypes.line: drawLine(geometry[i]); break;
			case objTypes.circle: drawCircle(geometry[i]); break;
			case objTypes.rect: drawRect(geometry[i]); break;
			default:break;
		}
	}
	
	for(var i=0;i<geometryOther.length;i++){
		switch(geometryOther[i].type)
		{
			case objTypes.line: drawLine(geometryOther[i]); break;
			case objTypes.circle: drawCircle(geometryOther[i]); break;
			case objTypes.rect: drawRect(geometryOther[i]); break;
			default:break;
		}
	}
}
			
function clearCanvas(){
	context.clearRect (0, 0, canvas.width, canvas.height);
	context.beginPath();
	context.closePath();
}