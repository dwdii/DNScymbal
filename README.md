DNSimple Record Updater Windows .Net Tray app / Service
=======================================================
Currently just a crude tray app with manual config via the app.config.


    <add key="EmailAddress" value="<your DNSimple email address>"/>
    <add key="Password" value="<your DNSimple password>"/>
    <add key="Domain" value="yourdomain.com"/>
    <add key="RecordId" value="<Record Id of record to update>"/>
    <add key="RecordName" value="<Name of Record>"/>
    <add key="UpdateFrequencyMinutes" value="60"/>

Use the DNSimple web interface to create the initial A record. 

The DNScymbal app will automatically use the jsonip.com service to get your public IP address
and post this IP to the specified record on the specified domain.
