function checkForm() {
  var username = document.getElementById("username").value;
  var useremail = document.getElementById("useremail").value;
  var phone = document.getElementById("phone").value;

  if (username === "") {
    alert("Name cannot be empty");
    return false;
  }

  if (useremail === "") {
    alert("Email cannot be empty");
    return false;
  }

  if (!useremail.includes("@")) {
    alert("Invalid email format");
    return false;
  }

  if (phone === "") {
    alert("Phone number required");
    return false;
  }

  if (phone.length !== 10) {
    alert("Phone number must be 10 digits");
    return false;
  }

  alert("Form submitted successfully!");
  return true;
}