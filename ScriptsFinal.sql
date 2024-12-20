USE [ClinicDB]
GO
/****** Object:  Table [dbo].[advice]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[advice](
	[adviceID] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentID] [int] NULL,
	[advice] [text] NULL,
 CONSTRAINT [PK__advice__EFAD50E90FA3622D] PRIMARY KEY CLUSTERED 
(
	[adviceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[patientID] [int] NULL,
	[physicianID] [int] NULL,
	[AppointmentDate] [date] NULL,
	[Criticality] [varchar](50) NULL,
	[Reason] [varchar](255) NULL,
	[Note] [text] NULL,
	[Status] [varchar](50) NULL,
	[ScheduleDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chemists]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chemists](
	[chemistID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[contact] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[chemistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[drugs]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[drugs](
	[drugID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[price] [money] NOT NULL,
	[Stock] [varchar](50) NOT NULL,
	[expiry] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[drugID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patientHistory]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patientHistory](
	[historyID] [int] IDENTITY(1,1) NOT NULL,
	[patientID] [int] NULL,
	[artifacts] [varchar](150) NULL,
	[notes] [varchar](150) NULL,
 CONSTRAINT [PK__patientH__19BDBDB3D2CD0E10] PRIMARY KEY CLUSTERED 
(
	[historyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patientReports]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patientReports](
	[reportID] [int] IDENTITY(1,1) NOT NULL,
	[patientID] [int] NOT NULL,
	[reportType] [varchar](50) NULL,
	[reportDate] [date] NULL,
	[reportDetails] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[reportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patients](
	[patientID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[contact] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[address] [varchar](50) NOT NULL,
	[gender] [varchar](50) NOT NULL,
	[status] [varchar](50) NOT NULL,
	[account] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[patientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientSymptoms]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientSymptoms](
	[PatientSymptomID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[SymptomID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientSymptomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PatientID] ASC,
	[SymptomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[physicians]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[physicians](
	[physicianID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[Specialisation] [varchar](50) NOT NULL,
	[contact] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[address] [varchar](255) NULL,
	[regNO] [int] NOT NULL,
 CONSTRAINT [PK_physicians] PRIMARY KEY CLUSTERED 
(
	[physicianID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PODrugLine]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PODrugLine](
	[POId] [int] NOT NULL,
	[PODrugId] [int] IDENTITY(1,1) NOT NULL,
	[DrugId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Rate] [money] NULL,
	[orderStatus] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PODrugLine] PRIMARY KEY CLUSTERED 
(
	[PODrugId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POHeader]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POHeader](
	[PoID] [int] IDENTITY(1,1) NOT NULL,
	[PODate] [datetime] NOT NULL,
	[SupplierId] [int] NOT NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_POHeader_1] PRIMARY KEY CLUSTERED 
(
	[PoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prescription]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prescription](
	[prescriptionID] [int] IDENTITY(1,1) NOT NULL,
	[adviceID] [int] NULL,
	[drugID] [int] NULL,
	[dosage] [varchar](255) NULL,
	[note] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[prescriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[suppliers]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[suppliers](
	[supplierID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[address] [varchar](50) NULL,
	[contact] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_suppliers] PRIMARY KEY CLUSTERED 
(
	[supplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[symptoms]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[symptoms](
	[symptomID] [int] IDENTITY(1,1) NOT NULL,
	[symptomName] [varchar](100) NULL,
	[Category] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[symptomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 19-12-2024 22:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Role] [varchar](50) NULL,
	[ReferenceId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[patients] ADD  DEFAULT ('unregister') FOR [account]
GO
ALTER TABLE [dbo].[PODrugLine] ADD  DEFAULT ('Pending') FOR [orderStatus]
GO
ALTER TABLE [dbo].[advice]  WITH CHECK ADD  CONSTRAINT [FK__advice__Appointm__4316F928] FOREIGN KEY([AppointmentID])
REFERENCES [dbo].[Appointment] ([AppointmentID])
GO
ALTER TABLE [dbo].[advice] CHECK CONSTRAINT [FK__advice__Appointm__4316F928]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([patientID])
REFERENCES [dbo].[patients] ([patientID])
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([physicianID])
REFERENCES [dbo].[physicians] ([physicianID])
GO
ALTER TABLE [dbo].[patientHistory]  WITH CHECK ADD  CONSTRAINT [FK__patientHi__patie__6B24EA82] FOREIGN KEY([patientID])
REFERENCES [dbo].[patients] ([patientID])
GO
ALTER TABLE [dbo].[patientHistory] CHECK CONSTRAINT [FK__patientHi__patie__6B24EA82]
GO
ALTER TABLE [dbo].[patientReports]  WITH CHECK ADD FOREIGN KEY([patientID])
REFERENCES [dbo].[patients] ([patientID])
GO
ALTER TABLE [dbo].[PatientSymptoms]  WITH CHECK ADD FOREIGN KEY([PatientID])
REFERENCES [dbo].[patients] ([patientID])
GO
ALTER TABLE [dbo].[PatientSymptoms]  WITH CHECK ADD FOREIGN KEY([SymptomID])
REFERENCES [dbo].[symptoms] ([symptomID])
GO
ALTER TABLE [dbo].[PODrugLine]  WITH CHECK ADD  CONSTRAINT [FK_PODrugLine_drugs] FOREIGN KEY([DrugId])
REFERENCES [dbo].[drugs] ([drugID])
GO
ALTER TABLE [dbo].[PODrugLine] CHECK CONSTRAINT [FK_PODrugLine_drugs]
GO
ALTER TABLE [dbo].[PODrugLine]  WITH CHECK ADD  CONSTRAINT [FK_PODrugLine_PODHeader] FOREIGN KEY([POId])
REFERENCES [dbo].[POHeader] ([PoID])
GO
ALTER TABLE [dbo].[PODrugLine] CHECK CONSTRAINT [FK_PODrugLine_PODHeader]
GO
ALTER TABLE [dbo].[POHeader]  WITH CHECK ADD  CONSTRAINT [FK_POHeader_suppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[suppliers] ([supplierID])
GO
ALTER TABLE [dbo].[POHeader] CHECK CONSTRAINT [FK_POHeader_suppliers]
GO
ALTER TABLE [dbo].[prescription]  WITH CHECK ADD  CONSTRAINT [FK__prescript__advic__45F365D3] FOREIGN KEY([adviceID])
REFERENCES [dbo].[advice] ([adviceID])
GO
ALTER TABLE [dbo].[prescription] CHECK CONSTRAINT [FK__prescript__advic__45F365D3]
GO
ALTER TABLE [dbo].[prescription]  WITH CHECK ADD FOREIGN KEY([drugID])
REFERENCES [dbo].[drugs] ([drugID])
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD CHECK  (([Criticality]='HIGH' OR [Criticality]='MED' OR [Criticality]='LOW'))
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD CHECK  (([Status]='CONFIRMED' OR [Status]='PENDING'))
GO
ALTER TABLE [dbo].[drugs]  WITH CHECK ADD CHECK  (([Stock]='NO' OR [Stock]='YES'))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  (([gender]='OTHER' OR [gender]='FEMALE' OR [gender]='MALE'))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  (([status]='INACTIVE' OR [status]='ACTIVE'))
GO
ALTER TABLE [dbo].[PODrugLine]  WITH CHECK ADD  CONSTRAINT [chk_orderStatus] CHECK  (([orderStatus]='Supplied' OR [orderStatus]='Rejected' OR [orderStatus]='Accepted' OR [orderStatus]='Pending'))
GO
ALTER TABLE [dbo].[PODrugLine] CHECK CONSTRAINT [chk_orderStatus]
GO
