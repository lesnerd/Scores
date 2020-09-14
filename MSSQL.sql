--
-- Table structure for table `SourceLocations`
--

DROP TABLE SourceLocations;
CREATE TABLE SourceLocations (
  Id varchar(36) PRIMARY KEY,
  LocationOnDisk varchar(28) DEFAULT NULL
);

--
-- Dumping data for table `SourceLocations`
--

INSERT INTO SourceLocations VALUES 
('2041F072-6F90-4813-81DA-03A2468010D5','C:\Temp\VaronisTest\Source1'),
('7E2E0C97-6F2F-48B2-91EE-36312247FD76','C:\Temp\VaronisTest\Source6'),
('DFA632E6-3D49-409C-BF8F-4D875D333282','C:\Temp\VaronisTest\Source7'),
('E9B3C5A4-E044-4985-9918-6A031920FFFE','C:\Temp\VaronisTest\Source2'),
('C02897F8-9DA6-429C-9A6F-7D0B60AAC979','C:\Temp\VaronisTest\Source8'),
('B38288D4-EFF8-4B36-A4AF-8F2EE4F24836','C:\Temp\VaronisTest\Source4'),
('E7855763-F7BB-45C4-9309-9668093A4DFE','C:\Temp\VaronisTest\Source3'),
('2E3B6FE1-838B-46BA-B10B-ABE502D2FA28','C:\Temp\VaronisTest\Source9'),
('ED182B16-08F8-41BB-9BE1-C5037D3F5E3B','C:\Temp\VaronisTest\Source10'),
('817DB312-8D26-4AC1-B829-FA0EBF063D83','C:\Temp\VaronisTest\Source5');
