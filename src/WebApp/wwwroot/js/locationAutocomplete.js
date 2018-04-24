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

    // Get Google Place ID.
    document.getElementById('placeId').value = place.place_id;

    var components = place.address_components;

    for (var i = 0, component; component = components[i]; i++) {
      // Get the street number.
      if (component.types[0] === 'street_number') {
        document.getElementById('street-number').value = component.long_name;
        continue;
      }
      // Get the street name.
      if (component.types[0] === 'route') {
        document.getElementById('street-name').value = component.short_name;
        continue;
      }
      // Get the city name.
      if (component.types[0] === 'locality') {
        document.getElementById('city').value = component.long_name;
        continue;
      }
      // Get the state name.
      if (component.types[0] === 'administrative_area_level_1') {
        document.getElementById('state').value = component.short_name;
        continue;
      }
      // Get the postal code.
      if (component.types[0] === 'postal_code') {
        document.getElementById('postal-code').value = component.long_name;
        continue;
      }
      // Get the country name.
      if (component.types[0] === 'country') {
        document.getElementById('country').value = component.long_name;
        continue;
      }
    }
  });
}