function validateData(form,x){
	//var field = document.input_form.elements;
	var name = document.getElementById(x).getAttribute('name');
	console.log(name);
	
	if(name == "first"){
	var fname = document.input_form.first.value;
	var regEx = /[a-zA-Z]/;
    	if(!fname.match(regEx)){
			//var elem = document.getElementById('fnamemsg');
			var err = document.createElement('span');
			err.setAttribute('id', 'msg1');
			var errText = document.createTextNode('Please enter a valid first name');
			var box = document.getElementById('fnamemsg');

			err.appendChild(errText);
			box.appendChild(err);
			}
    	}
    else if(name == "last"){
    	var lname = document.input_form.last.value;
    	var regEx = /[a-zA-Z]/;
    	if(!lname.match(regEx)){
    		var err = document.createElement('span');
			err.setAttribute('id', 'msg2');
			var errText = document.createTextNode('Please enter a valid last name');
			var box = document.getElementById('lnamemsg');

			err.appendChild(errText);
			box.appendChild(err);
			}
    	}
    else if(name == "email"){
    	var eAddress = document.input_form.email.value;
    	if(((eAddress != null) && (eAddress.length==0)) || ((eAddress != null) && (eAddress.length>0) && (eAddress.indexOf('@') == -1))) {
    		var err = document.createElement('span');
			err.setAttribute('id', 'msg3');
			var errText = document.createTextNode('Please enter a valid email');
			var box = document.getElementById('emailmsg');

			err.appendChild(errText);
			box.appendChild(err);
    	}
    }
    else if(name == "donation"){
    	var donate = document.input_form.donation.value;
    	var first = donate.charAt(0);
    	//console.log(first);
    	//var regEx = /^~/;
    	if(((donate != null) && (donate.length==0)) || ((donate != null) && (donate.length>0) && (donate.charAt(0) != '$'))) {
    		var err = document.createElement('span');
			err.setAttribute('id', 'msg4');
			var errText = document.createTextNode('Please enter a valid donation amount');
			var box = document.getElementById('donatemsg');

			err.appendChild(errText);
			box.appendChild(err);
    	}
    }	
}

function hint(form,x){
	var name = document.getElementById(x).getAttribute('name');

	if(name=="first"){
		var elem = document.getElementById('fnamemsg');
		 if (elem.childNodes.length > 0){
		 		var child = document.getElementById('msg1');
		 		child.remove();
		 }
	}
	else if(name=="last"){
		var elem = document.getElementById('lnamemsg');
		 if (elem.childNodes.length > 0){
		 		var child = document.getElementById('msg2');
		 		child.remove();
		 }
	}
	else if(name=="email"){
		var elem = document.getElementById('emailmsg');
		 if (elem.childNodes.length > 0){
		 		var child = document.getElementById('msg3');
		 		child.remove();
		 }
	}
	else if(name=="donation"){
		var elem = document.getElementById('donatemsg');
		 if (elem.childNodes.length > 0){
		 		var child = document.getElementById('msg4');
		 		child.remove();
		 }
	}	
}


