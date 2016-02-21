$(document).ready(function(){
$('[data-toggle="tooltip"]').tooltip();
$('.dropdown-toggle').dropdown()
$('.bxslider').bxSlider({
  infiniteLoop: false,
  hideControlOnEnd: true
});

  $('.slider4').bxSlider({
    slideWidth: 150,
    minSlides: 1,
    maxSlides: 7,
    moveSlides: 1,
    slideMargin: 10
  });

  $(function ()
  {
    $("#wizard").steps({
    headerTag: ".tab_head",
    bodyTag: "section",
    transitionEffect: "slideLeft"
    });
  });
  if (top.location != location) {
    top.location.href = document.location.href ;
  }
  $(function(){
  window.prettyPrint && prettyPrint();
  $('#dp1').datepicker({
	format: 'mm-dd-yyyy'
  });
  });
  $('#myfile').change(function(){
  //$('#path').val($(this).val());
  });
	var elem=$('ul.my_list');     
$('#viewcontrols a').on('click',function(e) {
 if ($(this).hasClass('gridview')) {
  elem.fadeOut(1000, function () {
  elem.removeClass('list').addClass('grid');
 elem.fadeIn(1000);
         });     
 }
 else if($(this).hasClass('listview')) {
  elem.fadeOut(1000, function () {
  elem.removeClass('grid').addClass('list');
  elem.fadeIn(1000);
        });        
 }
});
$('#viewcontrols a').click(function(){
$("#viewcontrols a").each(function() {
		$(this).removeClass('active');
	});
$(this).addClass('active');
});
$('#more_data').hide();
$('#viewmore').click(function(){
$('#more_data').slideToggle('slow');
$('#viewmore').hide();
});
$(function() {
$( "#slider-range" ).slider({
range: true,
min: 0,
max: 500,
values: [ 40, 400 ],
slide: function( event, ui ) {
$( "#amount" ).val( "$" + ui.values[ 0 ] + " - $" + ui.values[ 1 ] );
}
});
$( "#amount" ).val( "$" + $( "#slider-range" ).slider( "values", 0 ) +
" - $" + $( "#slider-range" ).slider( "values", 1 ) );
});

 if ($.fn.mixitup) {
			  $('#grid').mixitup( {
				filterSelector: '.filter-item'
			  } );
			  $(".filter-item").click(function(e) {
				e.preventDefault();
			  })
		  }

$('.edit_profile a').click(function(e){
e.preventDefault();
$('.user_profile_edit').show();
$('.user_profile_view').hide();
});
$('.edit_profile a#cancel').click(function(e){
e.preventDefault();
$('.user_profile_edit').hide();
$('.user_profile_view').show();
});
$(function() {
    $( "#accordion" ).accordion({
	heightStyle:"content"
	});
  });

});
