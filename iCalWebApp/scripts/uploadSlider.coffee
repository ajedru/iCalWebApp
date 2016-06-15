# CoffeeScript

window.toggleModal = (e) ->
	if !window.uploadVisible?
		window.uploadVisible = true

	$('.modal-content.modal-upload').slideToggle()
	if window.uploadVisible? &&  window.uploadVisible
		$('#upload').val('Cancel uploading')
		window.uploadVisible = false
	else
		$('#upload').val('Upload calendar')
		window.uploadVisible = true
	console.log "rogalik"
	return false
