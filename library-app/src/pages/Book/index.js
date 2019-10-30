import React from 'react'
import { Button, Card, Col, Container, Row, Table } from 'react-bootstrap'
import { connect } from 'react-redux'
import { deleteBook, fetchBooks } from '../../actions/book'
import Navbar from '../../components/Navbar'
import { CommandColumn } from './styles'
import { Link } from 'react-router-dom'

class Book extends React.Component {
  componentDidMount() {
    this.props.fetchBooks()
  }

  renderTableHead() {
    return (
      <thead>
        <tr>
          <th>Name</th>
          <th>Author</th>
          <th>Release Date</th>
          <th>Pages</th>
          <th>Publish Company</th>
          <th>&nbsp;</th>
        </tr>
      </thead>
    )
  }



  renderTableData(books) {
    return books.map((book, i) => {
      return (
        <tbody key={i}>
          <tr>
            <td>{book.name}</td>
            <td>{book.author}</td>
            <td>{book.releaseDate}</td>
            <td>{book.numberOfPages}</td>
            <td>{book.publishCompany}</td>
            <CommandColumn>
              <Link to="/bookForm" params={{id:book.id}}>Edit</Link>
              <Button onClick={() => this.props.deleteBook(book.id)} size="sm" variant="outline-danger">Delete</Button>
            </CommandColumn>
          </tr>
        </tbody>
      )
    })
  }

  render() {
    return (
      <>
        <Navbar />
        <Container>
          <Row>
            <Col lg="12">
              <Card border="light">
                <Card.Body>
                  <Card.Title>Books</Card.Title>
                  <Card.Body>
                    <Link to="/bookForm">
                      <Button variant="primary">New</Button>
                    </Link>
                  </Card.Body>
                    <Table striped bordered hover responsive size="sm">
                      {this.renderTableHead()}
                      {this.props.books.length ? this.renderTableData(this.props.books) : null}
                    </Table>
                </Card.Body>
              </Card>
            </Col>
          </Row>
        </Container>
      </>
    )
  }
}

const mapStateToProps = state => {
  return {
    books: state.books
  }
}

const mapDispatchToProps = {
  fetchBooks,
  deleteBook
}

export default connect(mapStateToProps, mapDispatchToProps)(Book)
