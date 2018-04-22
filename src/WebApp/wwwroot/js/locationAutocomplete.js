function initializeAutocomplete() {
  var input = document.getElementById('location');
  var autocomplete = new google.maps.places.Autocomplete(input);

  autocomplete.addListener('place_changed', function () {
    var place = autocomplete.getPlace();

    if (!place.geometry) {
      // User entered the name of a Place that was not suggested and
      // pressed the Enter key, or the Place Details request failed.
      window.alert("No details available for input: '" + place.name + "'");
      return;
    }

    document.getElementById('street-number').value = place.address_components[0].long_name;
    document.getElementById('street-name').value = place.address_components[1].long_name;
    document.getElementById('city').value = place.address_components[2].long_name;
    document.getElementById('state').value = place.address_components[4].short_name;
    document.getElementById('postal-code').value = place.address_components[6].long_name;
    document.getElementById('country').value = place.address_components[5].long_name;
  });
}