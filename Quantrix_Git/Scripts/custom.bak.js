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
  		var heightTotal = (liHeight * cont);

  		if($(this).hasClass('active')){
  			$(this).next().css({'height' : heightTotal });
  		}else{
  			$(this).next().css({'height' : '0' });
  		}
  		//$(this).next().css({'height' : divH })
  		//console.log(divH);
  	})

    $(document).on('click', '.loggedInDp', loadDropDiv);
}); 

function loadDropDiv() {
    if ($(".drop").hasClass("show")) {
        $(".drop").removeClass("show")
    }
    else {
        $(".drop").addClass("show");
    }    
}