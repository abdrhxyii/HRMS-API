The UI Design for HRMS - https://www.figma.com/design/bHF7HQpwTFWaB66tOanOuS/HR-Management-Admin---UI-Kit-(Community)?node-id=113-7674&t=D2R53NGEuwcZPZcI-0


EmployeeDataObjectStruture

{
  "employee": {
    "employeeId": "E12345",
    "firstName": "John",
    "lastName": "Doe",
    "mobileNumber": "+1234567890",
    "emailAddress": "john.doe@example.com",
    "dateOfBirth": "1985-05-15",
    "maritalStatus": "Single",
    "gender": "Male",
    "nationality": "American",
    "address": {
      "streetAddress": "123 Main St",
      "city": {
        "cityId": "C1",
        "cityName": "New York"
      },
      "state": {
        "stateId": "S1",
        "stateName": "New York"
      },
      "zipCode": "10001"
    },
    "employmentDetails": {
      "username": "johndoe",
      "employeeType": "Full-Time",
      "department": {
        "departmentId": "D1",
        "departmentName": "Engineering"
      },
      "designation": {
        "designationId": "DG1",
        "designationName": "Software Engineer"
      },
      "workingDays": "Monday-Friday",
      "joiningDate": "2020-01-15",
      "officeLocation": {
        "officeLocationId": "OL1",
        "locationName": "Headquarters",
        "address": {
          "streetAddress": "456 Corporate Blvd",
          "city": {
            "cityId": "C1",
            "cityName": "New York"
          },
          "state": {
            "stateId": "S1",
            "stateName": "New York"
          },
          "zipCode": "10010"
        }
      }
    },
    "contactInformation": {
      "slackId": "john.doe",
      "skypeId": "johndoe_skype",
      "githubId": "johndoe"
    },
    "documents": [
      {
        "documentId": "DOC1",
        "documentType": "AppointmentLetter",
        "filePath": "/path/to/appointment-letter.pdf"
      },
      {
        "documentId": "DOC2",
        "documentType": "SalarySlips",
        "filePath": "/path/to/salary-slips.pdf"
      },
      {
        "documentId": "DOC3",
        "documentType": "RelievingLetter",
        "filePath": "/path/to/relieving-letter.pdf"
      },
      {
        "documentId": "DOC4",
        "documentType": "ExperienceLetter",
        "filePath": "/path/to/experience-letter.pdf"
      }
    ]
  }
}
