$(document).ready(function () {
	$(".main_visual").hover(function(){
		$("#btn_prev,#btn_next").fadeIn()
	},function(){
		$("#btn_prev,#btn_next").fadeOut()
	});
	
	$dragBln = false;
	
	$(".main_image").touchSlider({
		flexible : true,
		speed : 200,
		btn_prev : $("#btn_prev"),
		btn_next : $("#btn_next"),
		paging : $(".flicking_con a"),
		counter : function (e){
			$(".flicking_con a").removeClass("on").eq(e.current-1).addClass("on");
		}
	});
	
	$(".main_image").bind("mousedown", function() {
		$dragBln = false;
	});
	
	$(".main_image").bind("dragstart", function() {
		$dragBln = true;
	});
	
	$(".main_image a").click(function(){
		if($dragBln) {
			return false;
		}
	});
	
	timer = setInterval(function(){
		$("#btn_next").click();
	}, 5000);
	
	$(".main_visual").hover(function(){
		clearInterval(timer);
	},function(){
		timer = setInterval(function(){
			$("#btn_next").click();
		},5000);
	});
	
	$(".main_image").bind("touchstart",function(){
		clearInterval(timer);
	}).bind("touchend", function(){
		timer = setInterval(function(){
			$("#btn_next").click();
		}, 5000);
	});
	$(".nav li").hover(
		function(){
			$(this).find("ul").show();
		},
		function(){
			$(this).find("ul").hide();
		}
	);
	timer1=setInterval(autoPlay1,3000);
	function autoPlay1(){
		$("#scroll").animate({marginLeft:'-229px'},1000,function(){
			$("#scroll").css({marginLeft:0}).find("li:first").appendTo("#scroll");
		});
	}
	$("#left").click(function(){
		clearInterval(timer1);
		$("#scroll").css({marginLeft:-229}).find("li:last").prependTo("#scroll");
 		$("#scroll").animate({marginLeft:'0px'},1000);
 		timer1=setInterval(autoPlay1,3000);
  	});
	$("#right").click(function(){
		clearInterval(timer1);
 		$("#scroll").animate({marginLeft:'-229px'},1000,function(){
			$("#scroll").css({marginLeft:0}).find("li:first").appendTo("#scroll");
		});
		timer1=setInterval(autoPlay1,3000);
  	});
});