import React, { Component } from 'react';
import './EneaTest.css';

export class EneaTest extends Component {
  static displayName = EneaTest.name;

 constructor(props) {
    super(props);

    this.state = {
        bpIn: '',
        lpsIn: '',
        snIn: '',
        bpOut: '',
        lpsOut: '',
        snOut: ''
    };

    this.handleBPChange = this.handleBPChange.bind(this);
    this.handleLPSChange = this.handleLPSChange.bind(this);
    this.handleListChange = this.handleListChange.bind(this);

    this.checkBalanced = this.checkBalanced.bind(this);
    this.determineLongestPrefix = this.determineLongestPrefix.bind(this);
    this.checkSortedNumbers = this.checkSortedNumbers.bind(this);
 }

 handleBPChange(event) {
    this.setState({ bpIn: event.target.value });
    this.setState({ bpOut: '' });
}

handleLPSChange(event) {
    this.setState({ lpsIn: event.target.value });
    this.setState({ lpsOut: '' });
}

handleListChange(event) {
    this.setState({ snIn: event.target.value });
    this.setState({ snOut: '' });
}

async checkBalanced(event) {
    const b64Expression = new Buffer(this.state.bpIn).toString('base64');
    const response = await fetch('BalancedParantheses/' + b64Expression);
        
    if (response.ok) {
        const data = await response.json();
        this.setState({ bpOut: data[1] });
    } else {
        this.setState({ bpOut: 'Encountered error!' });
    }
}

async determineLongestPrefix(event) {
    const b64Expression = new Buffer(this.state.lpsIn).toString('base64');
    const response = await fetch('LongestPrefixSuffix/' + b64Expression);

    if (response.ok) {
        const data = await response.json();
        this.setState({ lpsOut: data[1] });
    } else {
        this.setState({ lpsOut: 'Encountered error!' });
    }
}

async checkSortedNumbers(event) {
    const b64Expression = new Buffer(this.state.snIn).toString('base64');
    const response = await fetch('SortedNumbers/' + b64Expression);

    if (response.ok) {
        const data = await response.json();
        this.setState({ snOut: data[1] });
    } else {
        this.setState({ snOut: 'Encountered error!' });
    }
}

 render () {
    return (
      <div>
            <div className="algorithmSection">
                <h3>Check for balanced parentheses</h3>
                <div className="algorithmContents">
                    <input type="text" placeholder="Input" value={this.state.bpIn} onChange={this.handleBPChange} />
                    <button onClick={this.checkBalanced}>Check balanced</button>
                    <label placeholder="Output">{this.state.bpOut}</label>
                </div>
            </div>
            <hr />
            <div className="algorithmSection">
                <h3>Determine the longest prefix which is also suffix</h3>
                <div className="algorithmContents">
                    <input type="text" placeholder="Input" value={this.state.lpsIn} onChange={this.handleLPSChange} />
                    <button onClick={this.determineLongestPrefix}>Determine longest prefix</button>
                    <label placeholder="Output">{this.state.lpsOut}</label>
                </div>
            </div>
            <hr />
            <div className="algorithmSection">
                <h3>Check for list of sorted numbers</h3>
                <div className="algorithmContents">
                    <input type="text" placeholder="Input" value={this.state.snIn} onChange={this.handleListChange} />
                    <button onClick={this.checkSortedNumbers}>Check sorted numbers</button>
                    <label placeholder="Output">{this.state.snOut}</label>
                </div>
            </div>
      </div>
    );
  }
}
