﻿// Generated by IcedCoffeeScript 108.0.11
(function() {
  var key, value, zones;

  $(document).ready(zones = {
    "Central Europe Standard Time": "Central Europe Standard Time",
    "GMT Standard Time": "GMT Standard Time",
    "UTC": "UTC",
    "W. Europe Standard Time": "W. Europe Standard Time",
    "GTB Standard Time": "GTB Standard Time",
    "Egypt Standard Time": "Egypt Standard Time",
    "South Africa Standard Time": "South Africa Standard Time",
    "Arabic Standard Time": "Arabic Standard Time",
    "Russian Standard Time": "Russian Standard Time",
    "India Standard Time": "India Standard Time",
    "China Standard Time": "China Standard Time"
  }, (function() {
    var _results;
    _results = [];
    for (key in zones) {
      value = zones[key];
      if (!($("#timezone-select-from option[value='" + key + "']").length > 0)) {
        $('#timezone-select-from').append("<option value='" + key + "'>" + value + "</option>");
      }
      if (!($("#timezone-select-to option[value='" + key + "']").length > 0)) {
        _results.push($('#timezone-select-to').append("<option value='" + key + "'>" + value + "</option>"));
      } else {
        _results.push(void 0);
      }
    }
    return _results;
  })());

}).call(this);
