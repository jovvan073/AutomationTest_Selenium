# Selenium C# GUI Automation Tests for Magento Software Testing Board

This repository contains GUI automation tests written in C# using Selenium for the [Magento Software Testing Board](https://magento.softwaretestingboard.com/) website. These tests cover a variety of functionalities and scenarios to ensure the website behaves as expected.

## Test Cases

### Registration Page Tests
- **Empty Field Validation**: Automated tests were conducted to verify that all fields on the registration page must be filled out. A loop was implemented to systematically leave each field empty one at a time and assert that the appropriate error message is displayed when attempting to submit the form.

### Review and Checkout Tests
- **Leaving Reviews**: Automated tests were performed to simulate leaving product reviews. Assertions were made to ensure that the review submission process behaves correctly.
- **Checkout Process**: Tests were conducted to automate the checkout process. Conditional statements (if/else) were used to handle scenarios where certain buttons were expected to be clicked before proceeding.
