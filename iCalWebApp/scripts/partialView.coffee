# CoffeeScript
#Initialize numeric spinner input boxes
#$(".numeric-spinner").spinedit();
#Initialize modal dialog
#attach modal-container bootstrap attributes to links with .modal-link class.
#when a link is clicked with these attributes, bootstrap will display the href content in a modal dialog.
window.showModal = (e) -> 
	$('.modal-content.modal-upload').show() 
	debugger


window.cancelModal = () ->
	$('.modal-content.modal-upload').hide()

	$("#upload").click(window.toggleModal)

window.toggleModal = (e) ->
	if window.showUpload? && window.showUpload
		window.cancelModal()
		window.showUpload = false
	else
		window.showModal()
		window.showUpload = true




