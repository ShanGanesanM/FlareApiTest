Feature: Favourites

This feature file contains favourites related API test cases

@test1
Scenario: Verify user can add a favourites using an api
	When I send 'POST' request with imageId 'UI5' subId 'Shan4'
	Then I See the response is '200'
	And I see the 'SUCCESS' in message
	And I send 'GET' request with favouriteId '?sub_id=Shan4'
	And I see the response contains 'UI5'

@test2
Scenario: Verify user can get all favourites using get api
	 When I send 'GET' request with favouriteId '?sub_id=Shan3'
	 Then I See the response is '200'
	 And I see the response contains more than '1' response block

@test3
Scenario: Verify user can get specific favourite using get api
     When I send 'GET' request with favouriteId '100100567'
	 Then I See the response is '200'
	 And I see the response imageId contains 'Shan'

@test4
Scenario: Verify user can delete specific favourite using delete api
     When I send 'DELETE' request with favouriteId '100100571'
	 Then I See the response is '200'
	 And I see the response message contains 'SUCCESS'
	 And I send 'GET' request with favouriteId '?sub_id=Shan3'
	 And I see the response does not contain id '100100571'








