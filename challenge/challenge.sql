create database challenge;

use challenge;

-- Create tables
CREATE TABLE Crime (
 CrimeID INT PRIMARY KEY,
 IncidentType VARCHAR(255),
 IncidentDate DATE,
 Location VARCHAR(255),
 Description TEXT,
 Status VARCHAR(20)
);
CREATE TABLE Victim (
 VictimID INT PRIMARY KEY,
 CrimeID INT,
 Name VARCHAR(255),
 ContactInfo VARCHAR(255),
 Injuries VARCHAR(255),
 age int not null
 FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
);
CREATE TABLE Suspect (
 SuspectID INT PRIMARY KEY,
 CrimeID INT,
 Name VARCHAR(255),
 Description TEXT,
 CriminalHistory TEXT,
 age int not null
 FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
);


-- Insert sample data
INSERT INTO Crime (CrimeID, IncidentType, IncidentDate, Location, Description, Status)
VALUES
 (1, 'Robbery', '2023-09-15', '123 Main St, Cityville', 'Armed robbery at a convenience store', 'Open'),
 (2, 'Homicide', '2023-09-20', '456 Elm St, Townsville', 'Investigation into a murder case', 'Under Investigation'),
 (3, 'Theft', '2023-09-10', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Open'),
 (4, 'Assault', '2022-10-06', '123  St, Epping', 'Investigation into a murder case', 'Closed'),
 (5, 'Theft', '2023-04-16', '786  Rak squares, Townsville', 'Car Stealing', 'Open'),
 (6, 'Homicide', '2023-09-26', '456 Elm St, Townsville', 'Investigation into a murder case', 'Open'),
 (7, 'Robbery', '2022-09-26', '456 Bakers St, Townsville', 'Investigation into a car case', 'Open')


INSERT INTO Victim (VictimID, CrimeID, Name, ContactInfo, Injuries,age)
VALUES
 (1, 1, 'John Doe', 'johndoe@example.com', 'Minor injuries',18),
 (2, 2, 'Jane Smith', 'janesmith@example.com', 'Deceased',33),
 (3, 3, 'Alice Johnson', 'alicejohnson@example.com', 'None',30),
 (4, 4, 'Carl', 'carl@gmail.com', 'Minor injuries',29),
 (5, 5, 'James', 'Jamesjohn@gmail.com', 'None',48),
 (6, 6, 'Andrew', 'andrewshum@gmail.com', 'Hospitalized',19),
 (7, 7, 'Suresh', 'srshkpr@gmail.com', 'None',48)
 


INSERT INTO Suspect (SuspectID, CrimeID, Name, Description, CriminalHistory,age)
VALUES
 (1, 1, 'Rakesh', 'Armed and masked robber', 'Previous robbery convictions',19),
 (2, 2, 'Unknown', 'Investigation ongoing', NULL,31),
 (3, 3, 'Mukesh', 'Shoplifting suspect', 'Prior shoplifting arrests',45),
 (4, 4, 'James ', 'Armed and masked robber', 'Previous assault convictions',48),
 (5, 5, 'Carl ', 'Grand auto theft' , 'Previous stealing convictions',29),
 (6, 6, 'Suresh ', 'Investigation Going',  'Homicide' ,48),
 (7, 7, 'Mukesh ', 'Investigation Going',  'Car lifting' ,45)



 --1) Select all open incidents.

select * from Crime where status = 'Open'


--2) Find the total number of incidents.

select count(*) as [Total Incidents] from crime

--3) List all unique incident types.

select distinct IncidentType from crime


--4) Retrieve incidents that occurred between '2023-09-01' and '2023-09-10'.
select * from crime
where incidentdate between '2023-09-01' and '2023-09-10'

--5) List persons involved in incidents in descending order of age.

select name, age, 'victim' as role
from victim
union all
select name, age, 'suspect' as role
from suspect
order by age desc

--6) Find the average age of persons involved in incidents.

select avg(age) as [Average age]
from (select age from victim
union 
select age from suspect) as [Combined ages]


--7) List incident types and their counts, only for open cases.

select incidenttype, count(*) as incident_count
from crime
where status = 'Open'
group by incidenttype


--8) Find persons with names containing 'Doe'.

select name, 'victim' as role
from victim
where name like '%Doe%'
union 
select name, 'suspect' as role
from suspect
where name like '%Doe%'


--9) Retrieve the names of persons involved in open cases and closed cases.

select v.name as person_name, 'victim' as role
from victim v
join crime c on v.crimeid = c.crimeid
where c.status in ('Open', 'Closed')
union 
select s.name as person_name, 'suspect' as role
from suspect s
join crime c on s.crimeid = c.crimeid
where c.status in ('Open', 'Closed')


--10) List incident types where there are persons aged 30 or 35 involved.

select distinct c.incidenttype
from crime c
join victim v on c.crimeid = v.crimeid
where v.age between 30 and 35

union

select distinct c.incidenttype
from crime c
join suspect s on c.crimeid = s.crimeid
where s.age between 30 and 35



--11) Find persons involved in incidents of the same type as 'Robbery'.

select v.name as person_name, 'victim' as role
from victim v
join crime c on v.crimeid = c.crimeid
where c.incidenttype = 'Robbery'
 
union all

select s.name as person_name, 'suspect' as role
from suspect s
join crime c on s.crimeid = c.crimeid
where c.incidenttype = 'Robbery'

--12) List incident types with more than one open case.

select c.incidenttype, count(*) as [open case count]
from crime c
where c.status = 'Open'
group by c.incidenttype
having count(*) > 1


--13)List all incidents with suspects whose names also appear as victims in other incidents.

select distinct c.crimeid, c.incidenttype, s.name as [Name]
from suspect s
join victim v on s.name = v.name
join crime c on s.crimeid = c.crimeid


--14)Retrieve all incidents along with victim and suspect details.

select c.crimeid, c.incidenttype, c.incidentdate, c.location, c.description, c.status,
       v.name as victim_name, v.age as victim_age, v.contactinfo as victim_contact, v.injuries,
       s.name as suspect_name, s.age as suspect_age, s.description as suspect_description, s.criminalhistory
from crime c
 join victim v on c.crimeid = v.crimeid
 join suspect s on c.crimeid = s.crimeid


--15) Find incidents where the suspect is older than any victim.
select c.crimeid, c.incidenttype, c.incidentdate, c.location, c.description, c.status,
       s.name as [Suspect Name], s.age as [Suspect Age],
       v.name as [Victim Name], v.age as [Victim Age]
from crime c
join suspect s on c.crimeid = s.crimeid
join victim v on c.crimeid = v.crimeid
where s.age > v.age


--16) Find suspects involved in multiple incidents

select s.name as [Suspect Name], count(distinct s.crimeid) as [Incident Count]
from suspect s
group by s.name
having count(distinct s.crimeid) > 1

--17) List incidents with no suspects involved.

select c.crimeid, c.incidenttype, c.incidentdate, c.location, c.description, c.status
from crime c
left join suspect s on c.crimeid = s.crimeid
where s.name is null or s.name = 'Unknown'

--18) List all cases where at least one incident is of type 'Homicide' and all other incidents are of type 'Robbery'.

select * from crime
where incidenttype in ('Robbery', 'Homicide')


--19) Retrieve a list of all incidents and the associated suspects, showing suspects for each incident, or 'No Suspect' if there are none.

select *,isnull(s.name, 'No Suspect') as [Suspect Name] 
from crime c join suspect s on c.crimeid = s.crimeid  


--20) List all suspects who have been involved in incidents with incident types 'Robbery' or 'Assault'

select  s.suspectid,s.name, s.description,  s.criminalhistory
from suspect s
join crime c on s.crimeid = c.crimeid
where c.incidenttype in ('Robbery', 'Assault')






















