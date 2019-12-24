/*******************************************************************************
 * Default character set: NONE
 * Server version: 2.5
 * Server version string: WI-V2.5.8.27089 Firebird 2.5
 * Database ODS: 11.2
 * Database page size: 8192
 ******************************************************************************/

/*******************************************************************************
 * Selected metadata objects
 * -------------------------
 * Extracted at 2018-07-04 오후 3:28:24
 ******************************************************************************/

/*******************************************************************************
 * Roles
 * -----
 * Extracted at 2018-07-04 오후 3:28:24
 ******************************************************************************/

/* "PUBLIC" is a system role, no CREATE ROLE statement. */
/* "RDB$ADMIN" is a system role, no CREATE ROLE statement. */
/*******************************************************************************
 * UDFs
 * ----
 * Extracted at 2018-07-04 오후 3:28:24
 ******************************************************************************/

/*******************************************************************************
 * Sequences
 * ---------
 * Extracted at 2018-07-04 오후 3:28:24
 ******************************************************************************/

CREATE GENERATOR GN_ALLPARAM;
CREATE GENERATOR GN_CALIBPOINT;
CREATE GENERATOR GN_CALIBRATOR;
CREATE GENERATOR GN_CALIBRATOR_ROW;
CREATE GENERATOR GN_CONDITION_METHODPARAM;
CREATE GENERATOR GN_CONDITION_NOTEPARAM;
CREATE GENERATOR GN_CONDITION_RATEDPARAM;
CREATE GENERATOR GN_CONDITION_THERMOPRESSPARAM;
CREATE GENERATOR GN_SCHEDULEPARAM;
CREATE GENERATOR GN_USER;
/*******************************************************************************
 * Tables
 * ------
 * Extracted at 2018-07-04 오후 3:28:24
 ******************************************************************************/

CREATE TABLE TB_ALLPARAM 
(
  PK_RECNO               INTEGER         NOT NULL,
  FK_USERNO              INTEGER         NOT NULL,
  REGTIME                VARCHAR(    19) NOT NULL COLLATE NONE,
  MEMO                   VARCHAR(    50) NOT NULL COLLATE NONE,
 CONSTRAINT PK_TB_ALLPARAM PRIMARY KEY (PK_RECNO)
);
CREATE TABLE TB_CALIBPOINT 
(
  PK_RECNO                    INTEGER         NOT NULL,
  FK_CALIB_ROWNO              INTEGER         NOT NULL,
  POINTNO                     INTEGER         NOT NULL,
  PV                 DOUBLE PRECISION         NOT NULL,
  SV                 DOUBLE PRECISION         NOT NULL,
 CONSTRAINT PK_TB_CALIBPOINT PRIMARY KEY (PK_RECNO)
);
CREATE TABLE TB_CALIBRATOR 
(
  PK_RECNO               INTEGER         NOT NULL,
  FK_USERNO              INTEGER         NOT NULL,
  REGTIME                VARCHAR(    20) NOT NULL COLLATE NONE,
  MEMO                   VARCHAR(    80) NOT NULL COLLATE NONE,
 CONSTRAINT PK_TB_CALIBRATOR PRIMARY KEY (PK_RECNO)
);
CREATE TABLE TB_CALIBRATOR_ROW 
(
  PK_RECNO                     INTEGER         NOT NULL,
  FK_CALIBRATORNO              INTEGER         NOT NULL,
  CHANNEL                      INTEGER         NOT NULL,
  RAW_A               DOUBLE PRECISION         NOT NULL,
  RAW_B               DOUBLE PRECISION         NOT NULL,
  RAW_C               DOUBLE PRECISION         NOT NULL,
  DIFF_A              DOUBLE PRECISION         NOT NULL,
  DIFF_B              DOUBLE PRECISION         NOT NULL,
  DIFF_C              DOUBLE PRECISION         NOT NULL,
 CONSTRAINT PK_TB_CALIBRATOR_ROW PRIMARY KEY (PK_RECNO)
);
CREATE TABLE TB_CONDITION_METHODPARAM 
(
  PK_RECO                 INTEGER         NOT NULL,
  FK_NOTENO               INTEGER         NOT NULL,
  INTEGCOUNT              INTEGER         NOT NULL,
  INTEGTIME               INTEGER         NOT NULL,
  SCANTIME                INTEGER         NOT NULL,
  COOLCAPA                INTEGER         NOT NULL,
  HEATCAPA                INTEGER         NOT NULL,
  AIRFLOW                 INTEGER         NOT NULL,
  ENTHALPY                INTEGER         NOT NULL,
  PRESS                   INTEGER         NOT NULL,
  TEMP                    INTEGER         NOT NULL,
  DIFFPRESS               INTEGER         NOT NULL,
  ATMPRESS                INTEGER         NOT NULL,
  AUTOSET                 INTEGER         NOT NULL,
  USEPM                   INTEGER         NOT NULL,
 CONSTRAINT PK_TB_CONDITION_METHODPARAM PRIMARY KEY (PK_RECO)
);
CREATE TABLE TB_CONDITION_NOTEPARAM 
(
  PK_RECNO                INTEGER         NOT NULL,
  FK_PARAMNO              INTEGER         NOT NULL,
  COMPANY                 VARCHAR(    30) NOT NULL COLLATE NONE,
  TESTNAME                VARCHAR(    30) NOT NULL COLLATE NONE,
  TESTNO                  VARCHAR(    30) NOT NULL COLLATE NONE,
  OBSERVER                VARCHAR(    30) NOT NULL COLLATE NONE,
  MAKER                   VARCHAR(    30) NOT NULL COLLATE NONE,
  MODEL1                  VARCHAR(    30) NOT NULL COLLATE NONE,
  SERIAL1                 VARCHAR(    30) NOT NULL COLLATE NONE,
  MODEL2                  VARCHAR(    30) NOT NULL COLLATE NONE,
  SERIAL2                 VARCHAR(    30) NOT NULL COLLATE NONE,
  MODEL3                  VARCHAR(    30) NOT NULL COLLATE NONE,
  SERIAL3                 VARCHAR(    30) NOT NULL COLLATE NONE,
  EXPDEVICE               VARCHAR(    30) NOT NULL COLLATE NONE,
  REFRIGE                 VARCHAR(    30) NOT NULL COLLATE NONE,
  REFCHARGE               VARCHAR(    30) NOT NULL COLLATE NONE,
  MEMO                    VARCHAR(    50) NOT NULL COLLATE NONE,
  COOLUNIT                INTEGER         NOT NULL,
  HEATUNIT                INTEGER         NOT NULL,
 CONSTRAINT PK_TB_CONDITION_NOTEPARAM PRIMARY KEY (PK_RECNO)
);
CREATE TABLE TB_CONDITION_RATEDPARAM 
(
  PK_RECNO               INTEGER         NOT NULL,
  FK_NOTENO              INTEGER         NOT NULL,
  PAGENO                 INTEGER         NOT NULL,
  MODE                   INTEGER         NOT NULL,
  CAPACITY                 FLOAT         NOT NULL,
  POWER                    FLOAT         NOT NULL,
  EER_COP                  FLOAT         NOT NULL,
  VOLT                     FLOAT         NOT NULL,
  AMP                      FLOAT         NOT NULL,
  FREQ                   VARCHAR(    10) NOT NULL COLLATE NONE,
  PM_IDU                 INTEGER         NOT NULL,
  PM_ODU                 INTEGER         NOT NULL,
  PHASE                  INTEGER         NOT NULL,
 CONSTRAINT PK_TB_CONDITION_RATEDPARAM PRIMARY KEY (PK_RECNO)
);
CREATE TABLE TB_CONDITION_THERMOPRESSPARAM 
(
  PK_RECNO               INTEGER         NOT NULL,
  FK_NOTENO              INTEGER         NOT NULL,
  CHTYPE                 INTEGER         NOT NULL,
  CHNO                   INTEGER         NOT NULL,
  "NAME"                 VARCHAR(    40) NOT NULL COLLATE NONE,
 CONSTRAINT PK_TB_CONDITION_THERMOPRESS PRIMARY KEY (PK_RECNO)
);
CREATE TABLE TB_SCHEDULEPARAM 
(
  PK_RECNO                  INTEGER         NOT NULL,
  FK_PARAMNO                INTEGER         NOT NULL,
  STANDARD                  VARCHAR(    50) NOT NULL COLLATE NONE,
  "NAME"                    VARCHAR(    50) NOT NULL COLLATE NONE,
  NOOFSTEADY                INTEGER         NOT NULL,
  PREPARATION               INTEGER         NOT NULL,
  JUDGEMENT                 INTEGER         NOT NULL,
  REPEAT                    INTEGER         NOT NULL,
  ID1USE                    INTEGER         NOT NULL,
  ID1MODE1                  INTEGER         NOT NULL,
  ID1DUCT1                  INTEGER         NOT NULL,
  ID1MODE2                  INTEGER         NOT NULL,
  ID1DUCT2                  INTEGER         NOT NULL,
  ID1EDBSETUP                 FLOAT         NOT NULL,
  ID1EDBAVG                   FLOAT         NOT NULL,
  ID1EDBDEV                   FLOAT         NOT NULL,
  ID1EWBSETUP                 FLOAT         NOT NULL,
  ID1EWBAVG                   FLOAT         NOT NULL,
  ID1EWBDEV                   FLOAT         NOT NULL,
  ID1LDB1DEV                  FLOAT         NOT NULL,
  ID1LWB1DEV                  FLOAT         NOT NULL,
  ID1AF1DEV                   FLOAT         NOT NULL,
  ID1LDB2DEV                  FLOAT         NOT NULL,
  ID1LWB2DEV                  FLOAT         NOT NULL,
  ID1AF2DEV                   FLOAT         NOT NULL,
  ID1CDP1SETUP                FLOAT         NOT NULL,
  ID1CDP1AVG                  FLOAT         NOT NULL,
  ID1CDP1DEV                  FLOAT         NOT NULL,
  ID1CDP2SETUP                FLOAT         NOT NULL,
  ID1CDP2AVG                  FLOAT         NOT NULL,
  ID1CDP2DEV                  FLOAT         NOT NULL,
  ID2USE                    INTEGER         NOT NULL,
  ID2MODE1                  INTEGER         NOT NULL,
  ID2DUCT1                  INTEGER         NOT NULL,
  ID2MODE2                  INTEGER         NOT NULL,
  ID2DUCT2                  INTEGER         NOT NULL,
  ID2EDBSETUP                 FLOAT         NOT NULL,
  ID2EDBAVG                   FLOAT         NOT NULL,
  ID2EDBDEV                   FLOAT         NOT NULL,
  ID2EWBSETUP                 FLOAT         NOT NULL,
  ID2EWBAVG                   FLOAT         NOT NULL,
  ID2EWBDEV                   FLOAT         NOT NULL,
  ID2LDB1DEV                  FLOAT         NOT NULL,
  ID2LWB1DEV                  FLOAT         NOT NULL,
  ID2AF1DEV                   FLOAT         NOT NULL,
  ID2LDB2DEV                  FLOAT         NOT NULL,
  ID2LWB2DEV                  FLOAT         NOT NULL,
  ID2AF2DEV                   FLOAT         NOT NULL,
  ID2CDP1SETUP                FLOAT         NOT NULL,
  ID2CDP1AVG                  FLOAT         NOT NULL,
  ID2CDP1DEV                  FLOAT         NOT NULL,
  ID2CDP2SETUP                FLOAT         NOT NULL,
  ID2CDP2AVG                  FLOAT         NOT NULL,
  ID2CDP2DEV                  FLOAT         NOT NULL,
  ODUSE                     INTEGER         NOT NULL,
  ODDP                      INTEGER         NOT NULL,
  ODAUTOVOLT                INTEGER         NOT NULL,
  ODEDBSETUP                  FLOAT         NOT NULL,
  ODEDBAVG                    FLOAT         NOT NULL,
  ODEDBDEV                    FLOAT         NOT NULL,
  ODEWBSETUP                  FLOAT         NOT NULL,
  ODEWBAVG                    FLOAT         NOT NULL,
  ODEWBDEV                    FLOAT         NOT NULL,
  ODEDPSETUP                  FLOAT         NOT NULL,
  ODEDPAVG                    FLOAT         NOT NULL,
  ODEDPDEV                    FLOAT         NOT NULL,
  ODVOLT1SETUP                FLOAT         NOT NULL,
  ODVOLT1AVG                  FLOAT         NOT NULL,
  ODVOLT1DEV                  FLOAT         NOT NULL,
  ODVOLT2SETUP                FLOAT         NOT NULL,
  ODVOLT2AVG                  FLOAT         NOT NULL,
  ODVOLT2DEV                  FLOAT         NOT NULL,
 CONSTRAINT PK_TB_SCHEDULEPARAM PRIMARY KEY (PK_RECNO)
);
CREATE TABLE TB_USER 
(
  PK_RECNO               INTEGER         NOT NULL,
  "NAME"                 VARCHAR(    20) NOT NULL COLLATE NONE,
  AUTHORITY              INTEGER         NOT NULL,
  PASSWD                 VARCHAR(    60) NOT NULL COLLATE NONE,
  MEMO                   VARCHAR(   100) NOT NULL COLLATE NONE,
 CONSTRAINT PK_TB_USER PRIMARY KEY (PK_RECNO)
);
/*******************************************************************************
 * Indices
 * -------
 * Extracted at 2018-07-04 오후 3:28:24
 ******************************************************************************/

CREATE ASC INDEX IDX_NOTEPARAM_MAKER ON TB_CONDITION_NOTEPARAM (MAKER);
CREATE ASC INDEX IDX_NOTEPARAM_MODEL1 ON TB_CONDITION_NOTEPARAM (MODEL1);
CREATE ASC INDEX IDX_NOTEPARAM_SERIAL1 ON TB_CONDITION_NOTEPARAM (SERIAL1);
CREATE ASC INDEX IDX_SCHPARAM_NAME ON TB_SCHEDULEPARAM ("NAME");
CREATE ASC INDEX IDX_SCHPARAM_STANDARD ON TB_SCHEDULEPARAM (STANDARD);
/*******************************************************************************
 * Foreign Key Constraints
 * -----------------------
 * Extracted at 2018-07-04 오후 3:28:24
 ******************************************************************************/

ALTER TABLE TB_CONDITION_METHODPARAM ADD CONSTRAINT FK_METHOD_NOTE 
  FOREIGN KEY (FK_NOTENO) REFERENCES TB_CONDITION_NOTEPARAM
  (PK_RECNO) 
  ON DELETE NO ACTION
  ON UPDATE NO ACTION
;

ALTER TABLE TB_CONDITION_NOTEPARAM ADD CONSTRAINT FK_NOTEPARAM_ALLPARAM 
  FOREIGN KEY (FK_PARAMNO) REFERENCES TB_ALLPARAM
  (PK_RECNO) 
  ON DELETE NO ACTION
  ON UPDATE NO ACTION
;

ALTER TABLE TB_SCHEDULEPARAM ADD CONSTRAINT FK_SCHEDULEPARAM_ALLPARAM 
  FOREIGN KEY (FK_PARAMNO) REFERENCES TB_ALLPARAM
  (PK_RECNO) 
  ON DELETE NO ACTION
  ON UPDATE NO ACTION
;

ALTER TABLE TB_CALIBPOINT ADD CONSTRAINT FK_TB_CALIBPOINT_TB_CALIB_ROW 
  FOREIGN KEY (FK_CALIB_ROWNO) REFERENCES TB_CALIBRATOR_ROW
  (PK_RECNO) 
  ON DELETE NO ACTION
  ON UPDATE NO ACTION
;

ALTER TABLE TB_CALIBRATOR ADD CONSTRAINT FK_TB_CALIBRATOR_TB_USER 
  FOREIGN KEY (FK_USERNO) REFERENCES TB_USER
  (PK_RECNO) 
  ON DELETE NO ACTION
  ON UPDATE NO ACTION
;

ALTER TABLE TB_CALIBRATOR_ROW ADD CONSTRAINT FK_TB_CALIB_ROW_TB_CALIB 
  FOREIGN KEY (FK_CALIBRATORNO) REFERENCES TB_CALIBRATOR
  (PK_RECNO) 
  ON DELETE NO ACTION
  ON UPDATE NO ACTION
;

ALTER TABLE TB_CONDITION_RATEDPARAM ADD CONSTRAINT FK_TB_RATEDPARAM_TB_NOTEPARAM 
  FOREIGN KEY (FK_NOTENO) REFERENCES TB_CONDITION_NOTEPARAM
  (PK_RECNO) 
  ON DELETE NO ACTION
  ON UPDATE NO ACTION
;

ALTER TABLE TB_CONDITION_THERMOPRESSPARAM ADD CONSTRAINT FK_THERMOPRESSPARAM_NOTEPARAM 
  FOREIGN KEY (FK_NOTENO) REFERENCES TB_CONDITION_NOTEPARAM
  (PK_RECNO) 
  ON DELETE NO ACTION
  ON UPDATE NO ACTION
;

