﻿// Generated by IcedCoffeeScript 108.0.11
(function() {
  var key, value, zones;

  $(document).ready(zones = {
    "GM": "GMT Standard Time",
    "UT": "UTC",
    "WE": "W. Europe Standard Time",
    "CE": "Central Europe Standard Time",
    "GT": "GTB Standard Time",
    "EG": "Egypt Standard Time",
    "SA": "South Africa Standard Time",
    "AS": "Arabic Standard Time",
    "RU": "Russian Standard Time",
    "IS": "India Standard Time",
    "CH": "China Standard Time"
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