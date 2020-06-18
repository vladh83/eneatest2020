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
        snOut: '',
        bpOutCls: 'algorithmOk',
        lpsOutCls: 'algorithmOk',
        snOutCls: 'algorithmOk'
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
        if (data[0] !== 0) {
            this.setState({ bpOutCls: 'algorithmError' });
        } else {
            this.setState({ bpOutCls: 'algorithmOk' });
        }
        this.setState({ bpOut: data[1] });
    } else {
        this.setState({ bpOutCls: 'algorithmError' });
        this.setState({ bpOut: 'Encountered error!' });
    }
}

async determineLongestPrefix(event) {
    const b64Expression = new Buffer(this.state.lpsIn).toString('base64');
    const response = await fetch('LongestPrefixSuffix/' + b64Expression);

    if (response.ok) {
        const data = await response.json();
        if (data[0] !== 0) {
            this.setState({ lpsOutCls: 'algorithmError' });
        } else {
            this.setState({ lpsOutCls: 'algorithmOk' });
        }
        this.setState({ lpsOut: data[1] });
    } else {
        this.setState({ lpsOutCls: 'algorithmError' });
        this.setState({ lpsOut: 'Encountered error!' });
    }
}

async checkSortedNumbers(event) {
    const b64Expression = new Buffer(this.state.snIn).toString('base64');
    const response = await fetch('SortedNumbers/' + b64Expression);

    if (response.ok) {
        const data = await response.json();
        if (data[0] !== 0) {
            this.setState({ snOutCls: 'algorithmError' });
        } else {
            this.setState({ snOutCls: 'algorithmOk' });
        }
        this.setState({ snOut: data[1] });
    } else {
        this.setState({ snOutCls: 'algorithmError' });
        this.setState({ snOut: 'Encountered error!' });
    }
}

 render () {
    return (
      <div>
            <div className="algorithmSection">
                <h3>Check for balanced parentheses</h3>
                <div className="algorithmContents">
                    <div>
                        <input type="text" placeholder="Input" value={this.state.bpIn} onChange={this.handleBPChange} className="algorithmInput" />
                        <button className="algorithmTrigger" onClick={this.checkBalanced}>Check balanced</button>
                    </div>
                    <label placeholder="Output" className={`algorithmOutput ${this.state.bpOutCls}`}>{this.state.bpOut}</label>
                </div>
            </div>
            <hr />
            <div className="algorithmSection">
                <h3>Determine the longest prefix which is also suffix</h3>
                <div className="algorithmContents">
                    <div>
                        <input type="text" placeholder="Input" value={this.state.lpsIn} onChange={this.handleLPSChange} className="algorithmInput" />
                        <button className="algorithmTrigger" onClick={this.determineLongestPrefix}>Determine longest prefix</button>
                    </div>
                    <label placeholder="Output" className={`algorithmOutput ${this.state.lpsOutCls}`}>{this.state.lpsOut}</label>
                </div>
            </div>
            <hr />
            <div className="algorithmSection">
                <h3>Check for list of sorted numbers</h3>
                <div className="algorithmContents">
                    <div>
                        <input type="text" placeholder="Input" value={this.state.snIn} onChange={this.handleListChange} className="algorithmInput" />
                        <button className="algorithmTrigger" onClick={this.checkSortedNumbers}>Check sorted numbers</button>
                    </div>
                    <label placeholder="Output" className={`algorithmOutput ${this.state.snOutCls}`}>{this.state.snOut}</label>
                </div>
            </div>
      </div>
    );
  }
}
