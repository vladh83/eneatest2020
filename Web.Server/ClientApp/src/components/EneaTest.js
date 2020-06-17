import React, { Component } from 'react';
import './EneaTest.css';

export class EneaTest extends Component {
  static displayName = EneaTest.name;

 constructor(props) {
    super(props);

    this.state = {
        bpIn: '',
        lpsIn: '',
        listIn: '',
        bpOut: '',
        lpsOut: '',
        listOut: ''
    };

    this.handleBPChange = this.handleBPChange.bind(this);
    this.handleLPSChange = this.handleLPSChange.bind(this);
    this.handleListChange = this.handleListChange.bind(this);
 }

handleBPChange(event) {
    this.setState({ bpOut: '' });
}

handleLPSChange(event) {
    this.setState({ lpsOut: '' });
}

handleListChange(event) {
    this.setState({ listOut: '' });
}

 render () {
    return (
      <div>
            <div className="algorithmSection">
                <h3>Check for balanced parentheses</h3>
                <div className="algorithmContents">
                    Input: <input type="text" value={this.state.bpIn} onChange={this.handleBPChange} />
                    Output: 
                </div>
            </div>
            <hr />
            <div className="algorithmSection">
                <h3>Determine the longest prefix which is also suffix</h3>
                <div className="algorithmContents">
                    Input: <input type="text" value={this.state.lpsIn} onChange={this.handleLPSChange} />
                    Output:
                </div>
            </div>
            <hr />
            <div className="algorithmSection">
                <h3>Check for list of sorted numbers</h3>
                <div className="algorithmContents">
                    Input: <input type="text" value={this.state.listIn} onChange={this.handleListChange} />
                    Output:
                </div>
            </div>
      </div>
    );
  }
}
