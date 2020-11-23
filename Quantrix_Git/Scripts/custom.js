jQuery(document).ready(function($) {

	$("input.form-control").focus(function(){
   		$(this).parent().addClass("focused");

  	}).blur(function(){
   		$(this).parent().removeClass("focused");
   		//$(this).parent().addClass("focused");
  	})

  	////// Nav link
  	$('.left-sidebar-menu ul.parent-nav > li > a').next().css({'height' : '0' });
  	$('.left-sidebar-menu ul.parent-nav > li > a').click(function(){
  		//$('.left-sidebar-menu ul.parent-nav > li > a').not(this).removeClass('active');
  		$(this).toggleClass('active');
  		var liHeight = $(this).next().find('li').outerHeight();
  		var cont = $(this).next().find('li').length;
  		var heightTotal = liHeight * cont;

  		if($(this).hasClass('active')){
  			$(this).next().css({'height' : heightTotal });
  		}else{
  			$(this).next().css({'height' : '0' });
  		}
  		//$(this).next().css({'height' : divH })
  		//console.log(divH);
	})
	  
	///// Mobile menu open/close
	$('.mobMenu').click(function(){
		$('.left-sidebar').toggleClass('active');
	})
	$('.menuOverlay').click(function(){
		$('.left-sidebar').removeClass('active');
	})

	///// Filter sub menu
	$('.filter-op .sub-filter').click(function(){
		$(this).toggleClass('active');
		$('.filter-drop').toggleClass('active');
	})

  //// custom scroll
  $('#slimtest1').slimScroll({
      position: 'right',
        height: '98%',
        railVisible: true,
        alwaysVisible: true
      });

  $(".topmenusect").click(function(){
    $('body').toggleClass('smnav')
  });

}); 