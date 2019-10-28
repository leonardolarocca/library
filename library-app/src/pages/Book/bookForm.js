import React from 'react'
import Navbar from '../../components/Navbar'
import { Form, Container, Row, Col, Card, Button } from 'react-bootstrap'
import { insertBook } from '../../actions/book'
import { connect } from 'react-redux'

class BookForm extends React.Component {
  constructor(props) {
    super(props)

    this.state = {
      name: '',
      author: '',
      releaseDate: '',
      numberOfPages: '',
      publishCompany: ''
    }
  }

  handleChange = (e) => {
    const { name, value } = e.target
    
    this.setState({
      [name]: value
    })
  }

 handleSubmit = (e) => {
    e.preventDefault();
    this.props.insertBook(this.state)
  }
  render () {
    return (
      <>
      <Navbar />
      <Container>
        <Row>
          <Col lg="12">
            <Card border="light">
              <Card.Body>
                <Form onSubmit={this.handleSubmit}>
                  <Button type="submit" variant="primary">Save</Button>
                  <Form.Row>
                    <Form.Group as={Col} controlId="name">
                      <Form.Label>Book name</Form.Label>
                      <Form.Control name="name" onChange={this.handleChange} type="text"></Form.Control>
                    </Form.Group>
                    <Form.Group as={Col} controlId="author">
                      <Form.Label>Author</Form.Label>
                      <Form.Control name="author" onChange={this.handleChange} type="text"></Form.Control>
                    </Form.Group>
                  </Form.Row>
                  <Form.Row>
                    <Form.Group as={Col} controlId="releaseDate">
                      <Form.Label>Release date</Form.Label>
                      <Form.Control name="releaseDate" onChange={this.handleChange} type="date"></Form.Control>
                    </Form.Group>
                    <Form.Group as={Col} controlId="pages">
                      <Form.Label>Pages</Form.Label>
                      <Form.Control name="numberOfPages" onChange={this.handleChange} type="number"></Form.Control>
                    </Form.Group>
                    <Form.Group as={Col} controlId="publishCompany">
                      <Form.Label>Publish company</Form.Label>
                      <Form.Control name="publishCompany" onChange={this.handleChange} type="text"></Form.Control>
                    </Form.Group>
                  </Form.Row>
                </Form>
              </Card.Body>
            </Card>

          </Col>
        </Row>
      </Container>
    </>
    )
  }
};

const mapDispatchToProps = {
  insertBook
}

export default connect(null, mapDispatchToProps)(BookForm)