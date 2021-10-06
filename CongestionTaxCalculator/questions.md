Questions:

Am i allowed to use a third party package to check for toll free days? / Do we got any tool/package that we can use for this?
What or who is going to use this api? Can we expect the vehicle as strings or should we make it a enum incase it will be used manually?
I skipped using the 2013 dates even thou it could be usefull. I made my own function for checking holidays instead, but it ended up a bit ugly.
Should we save the data that this endpoint produces? is it going to be used to create bills?
What form off validation do we want? do we have to check thats an actuall vehicle running past?
Should i set the toll date to DateTime.Now or should we be able to send it in?
Ive made it now so everything is dependent on the date that is sent in. Hope that is ok

