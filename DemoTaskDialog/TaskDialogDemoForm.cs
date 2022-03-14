using System;
using System.Windows.Forms;

namespace DemoTaskDialog
{
    public partial class TaskDialogDemoForm : System.Windows.Forms.Form
    {
        public TaskDialogDemoForm()
        {
            InitializeComponent();
        }

        //
        // Demos 1-7 are directly copied from 
        // https://github.com/dotnet/winforms/issues/146
        // 
        // Demo 8 (RadioButton) is new
        //

        private void button1_Click(object sender, EventArgs e)
        {
            TaskDialogButton resultButton = TaskDialog.ShowDialog(new TaskDialogPage()
            {
                Text = "Hello World!",
                Heading = "Hello Task Dialog!   👍",
                Caption = "Dialog Title",
                Buttons = {
                    TaskDialogButton.Yes,
                    TaskDialogButton.Cancel
                },
                Icon = TaskDialogIcon.ShieldSuccessGreenBar
            });
            txtResult.Text = resultButton.ToString();

            if (resultButton == TaskDialogButton.Yes)
            {
                // Do something...
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaskDialogCommandLinkButton buttonRestart = new TaskDialogCommandLinkButton()
            {
                Text = "&Restart under different credentials",
                DescriptionText = "This text will be shown in the second line.",
                ShowShieldIcon = true
            };

            TaskDialogCommandLinkButton buttonCancelTask = new TaskDialogCommandLinkButton()
            {
                Text = "&Cancel the Task and return"
            };

            var page = new TaskDialogPage()
            {
                Icon = TaskDialogIcon.Shield,
                Heading = "This task requires the application to have elevated permissions.",
                // TODO - Hyperlinks will be possible in a future version
                Text = "Why is using the Administrator or other account necessary?",

                // TODO - will be possible in a future version
                //EnableHyperlinks = true,

                Buttons =
                {
                    TaskDialogButton.Cancel,
                    buttonRestart,
                    buttonCancelTask
                },
                DefaultButton = buttonCancelTask,

                // Show a expander.
                Expander = new TaskDialogExpander()
                {
                    Text = "Some expanded Text",
                    CollapsedButtonText = "View error information",
                    ExpandedButtonText = "Hide error information",
                    Position = TaskDialogExpanderPosition.AfterFootnote
                }
            };

            // Show the dialog and check the result.
            TaskDialogButton result = TaskDialog.ShowDialog(page);
            txtResult.Text = result.ToString();

            if (result == buttonRestart)
            {
                Console.WriteLine("Restarting...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Disable the "Yes" button and only enable it when the check box is checked.
            // Also, don't close the dialog when this button is clicked.
            var initialButtonYes = TaskDialogButton.Yes;
            initialButtonYes.Enabled = false;
            initialButtonYes.AllowCloseDialog = false;

            var initialPage = new TaskDialogPage()
            {
                Caption = "My Application",
                Heading = "Clean up database?",
                Text = "Do you really want to do a clean-up?\nThis action is irreversible!",
                Icon = TaskDialogIcon.ShieldWarningYellowBar,
                AllowCancel = true,

                Verification = new TaskDialogVerificationCheckBox()
                {
                    Text = "I know what I'm doing"
                },

                Buttons =
                {
                    TaskDialogButton.No,
                    initialButtonYes
                },
                DefaultButton = TaskDialogButton.No
            };

            // For the "In Progress" page, don't allow the dialog to close, by adding
            // a disabled button (if no button was specified, the task dialog would
            // get an (enabled) 'OK' button).
            var inProgressCloseButton = TaskDialogButton.Close;
            inProgressCloseButton.Enabled = false;

            var inProgressPage = new TaskDialogPage()
            {
                Caption = "My Application",
                Heading = "Operation in progress...",
                Text = "Please wait while the operation is in progress.",
                Icon = TaskDialogIcon.Information,

                ProgressBar = new TaskDialogProgressBar()
                {
                    State = TaskDialogProgressBarState.Marquee,
                    //MarqueeSpeed=10
                },

                Expander = new TaskDialogExpander()
                {
                    Text = "Initializing...",
                    Position = TaskDialogExpanderPosition.AfterFootnote
                },

                Buttons =
                {
                    inProgressCloseButton
                }
            };

            var finishedPage = new TaskDialogPage()
            {
                Caption = "My Application",
                Heading = "Success!",
                Text = "The operation finished.",
                Icon = TaskDialogIcon.ShieldSuccessGreenBar,
                Buttons =
                {
                    TaskDialogButton.Close
                }
            };

            TaskDialogButton showResultsButton = new TaskDialogCommandLinkButton("Show &Results");
            finishedPage.Buttons.Add(showResultsButton);

            // Enable the "Yes" button only when the checkbox is checked.
            TaskDialogVerificationCheckBox checkBox = initialPage.Verification;
            checkBox.CheckedChanged += (sender2, e2) =>
            {
                initialButtonYes.Enabled = checkBox.Checked;
            };

            // When the user clicks "Yes", navigate to the second page.
            initialButtonYes.Click += (sender2, e2) =>
            {
                // Navigate to the "In Progress" page that displays the
                // current progress of the background work.
                initialPage.Navigate(inProgressPage);

                // NOTE: When you implement a "In Progress" page that represents
                // background work that is done e.g. by a separate thread/task,
                // which eventually calls Control.Invoke()/BeginInvoke() when
                // its work is finished in order to navigate or update the dialog,
                // then DO NOT start that work here already (directly after
                // setting the Page property). Instead, start the work in the
                // TaskDialogPage.Created event of the new page.
                //
                // This is because if you started it here, then when that other
                // thread/task finishes and calls BeginInvoke() to call a method in
                // the GUI thread to update or navigate the dialog, there is a chance
                // that the callback might be called before the dialog completed
                // navigation (*) (as indicated by the Created event of the
                // new page), and the dialog might not be updatable in that case.
                // (The dialog can be closed or navigated again, but you cannot
                // change e.g. text properties of the page).
                //
                // If that's not possible for some reason, you need to ensure
                // that you delay the call to update the dialog until the Created
                // event of the next page has occured.
                // 
                // 
                // (*) Background info: Although the WinForms implementation of
                // Control.Invoke()/BeginInvoke() posts a new message in the
                // control's owning thread's message queue every time it is
                // called (so that the callback can be called later by the
                // message loop), when processing the posted message in the
                // control's window procedure, it calls ALL stored callbacks
                // instead of only the next one.
                // 
                // This means that even if you start the work after setting
                // the Page property (which means BeginInvoke() can only be
                // called AFTER starting navigation), the callback specified
                // by BeginInvoke might still be called BEFORE the task dialog
                // can process its posted navigation message.
            };

            // Simulate work by using a WinForms timer where we are updating the
            // progress bar and the expander with the current status.
            System.Windows.Forms.Timer timer = null;
            inProgressPage.Created += (s2, e2) =>
            {
                // The page is now being displayed, so create the timer.
                timer = new System.Windows.Forms.Timer()
                {
                    Interval = 200,
                    Enabled = true
                };

                int currentTimerValue = 0;
                timer.Tick += (s3, e3) =>
                {
                    currentTimerValue++;

                    var progressBar = inProgressPage.ProgressBar;
                    if (currentTimerValue >= 15 && currentTimerValue <= 40)
                    {
                        if (currentTimerValue == 15)
                        {
                            // Switch the progress bar to a regular one.
                            progressBar.State = TaskDialogProgressBarState.Normal;
                        }

                        progressBar.Value = (currentTimerValue - 15) * 4;
                        inProgressPage.Expander.Text = $"Progress: {progressBar.Value} %";
                    }
                    else if (currentTimerValue == 41)
                    {
                        // Work is finished, so navigate to the third page.
                        inProgressPage.Navigate(finishedPage);
                    }
                };
            };
            inProgressPage.Destroyed += (s2, e2) =>
            {
                // The page is being destroyed, so dispose of the timer.
                timer.Dispose();
                timer = null;
            };

            // Show the dialog (modeless).
            TaskDialogButton result = TaskDialog.ShowDialog(initialPage);
            txtResult.Text = result.ToString();

            if (result == showResultsButton)
            {
                Console.WriteLine("Showing Results!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TaskDialogButton btnCancel = TaskDialogButton.Cancel;
            TaskDialogButton btnSave = new TaskDialogButton("&Save");
            TaskDialogButton btnDontSave = new TaskDialogButton("Do&n't save");

            var page = new TaskDialogPage()
            {
                Caption = "My Application",
                Heading = "Do you want to save changes to Untitled?",
                Buttons =
                {
                    btnCancel,
                    btnSave,
                    btnDontSave
                }
            };

            // Show a modal dialog, then check the result.
            TaskDialogButton result = TaskDialog.ShowDialog(this, page);
            txtResult.Text = result.ToString();

            if (result == btnSave)
                Console.WriteLine("Saving");
            else if (result == btnDontSave)
                Console.WriteLine("Not saving");
            else
                Console.WriteLine("Canceling");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var page = new TaskDialogPage()
            {
                Caption = "Minesweeper",
                Heading = "What level of difficulty do you want to play?",
                AllowCancel = true,

                Footnote = new TaskDialogFootnote()
                {
                    Text = "Note: You can change the difficulty level later " +
                         "by clicking Options on the Game menu.",
                },

                Buttons =
                {
                    new TaskDialogCommandLinkButton("&Beginner", "10 mines, 9 x 9 tile grid")
                    {
                        Tag = 10
                    },
                    new TaskDialogCommandLinkButton("&Intermediate", "40 mines, 16 x 16 tile grid")
                    {
                        Tag = 40
                    },
                    new TaskDialogCommandLinkButton("&Advanced", "99 mines, 16 x 30 tile grid")
                    {
                        Tag = 99
                    }
                }
            };

            TaskDialogButton result = TaskDialog.ShowDialog(this, page);
            txtResult.Text = result.ToString();

            if (result.Tag is int resultingMines)
                Console.WriteLine($"Playing with {resultingMines} mines...");
            else
                Console.WriteLine("User canceled.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var page = new TaskDialogPage()
            {
                Caption = "My App Security",
                Heading = "Opening these files might be harmful to your computer",
                Text = "Your Internet security settings blocked one or more files from " +
                    "being opened. Do you want to open these files anyway?",
                Icon = TaskDialogIcon.ShieldWarningYellowBar,
                //Icon = TaskDialogIcon.ShieldGrayBar,
                // TODO - will be possible in a future version
                //EnableHyperlinks = true,

                Expander = new TaskDialogExpander("My-File-Sample.exe"),

                Footnote = new TaskDialogFootnote()
                {
                    // TODO - Hyperlinks will be possible in a future version
                    Text = "How do I decide whether to open these files?",
                    Icon = TaskDialogIcon.ShieldSuccessGreenBar
                },

                Buttons =
                {
                    TaskDialogButton.OK,
                    TaskDialogButton.Cancel
                },
                DefaultButton = TaskDialogButton.Cancel
            };

            TaskDialogButton result = TaskDialog.ShowDialog(this, page);
            txtResult.Text = result.ToString();

            if (result == TaskDialogButton.OK)
            {
                Console.WriteLine("OK selected");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            const string textFormat = "Reconnecting in {0} seconds...";
            int remainingTenthSeconds = 50;

            var reconnectButton = new TaskDialogButton("&Reconnect now");
            var cancelButton = TaskDialogButton.Cancel;

            var page = new TaskDialogPage()
            {
                Heading = "Connection lost; reconnecting...",
                Text = string.Format(textFormat, (remainingTenthSeconds + 9) / 10),
                ProgressBar = new TaskDialogProgressBar()
                {
                    State = TaskDialogProgressBarState.Paused
                },
                Buttons =
                {
                    reconnectButton,
                    cancelButton
                }
            };

            // Create a WinForms timer that raises the Tick event every tenth second.
            using (var timer = new System.Windows.Forms.Timer())
            {
                timer.Interval = 100;
                timer.Enabled = true;

                timer.Tick += (s2, e2) =>
                {
                    remainingTenthSeconds--;
                    if (remainingTenthSeconds > 0)
                    {
                        // Update the remaining time and progress bar.
                        page.Text = string.Format(textFormat, (remainingTenthSeconds + 9) / 10);
                        page.ProgressBar.Value = 100 - remainingTenthSeconds * 2;
                    }
                    else
                    {
                        // Stop the timer and click the "Reconnect" button - this will
                        // close the dialog.
                        timer.Enabled = false;
                        reconnectButton.PerformClick();
                    }
                };

                TaskDialogButton result = TaskDialog.ShowDialog(this, page);
                txtResult.Text = result.ToString();

                if (result == reconnectButton)
                    Console.WriteLine("Reconnecting.");
                else
                    Console.WriteLine("Not reconnecting.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var page = new TaskDialogPage()
            {
                Caption = "Minesweeper",
                Heading = "What level of difficulty do you want to play?",
                AllowCancel = true,

                Footnote = new TaskDialogFootnote()
                {
                    Text = "Note: You can change the difficulty level later " +
                         "by clicking Options on the Game menu.",
                },

                RadioButtons =
                {
                    new TaskDialogRadioButton("&Beginner")
                    {
                        Tag = 10
                    },
                    new TaskDialogRadioButton("&Intermediate")
                    {
                        Tag = 40
                    },
                    new TaskDialogRadioButton("&Advanced")
                    {
                        Tag = 99
                    }
                },
                Buttons =
                {
                    TaskDialogButton.OK,
                    TaskDialogButton.Cancel
                },
                DefaultButton = TaskDialogButton.Cancel
            };

            // Which RadioButton is selected is not returned by the TaskDialog
            // Add your own event handler to track which is selected.
            // Note that CheckedChanged is fired for checked and unchecked, but checked is always fired last.

            int level = 0;
            page.RadioButtons[0].CheckedChanged += (s, e1) => level = (int)(s as TaskDialogRadioButton).Tag;
            page.RadioButtons[1].CheckedChanged += (s, e1) => level = (int)(s as TaskDialogRadioButton).Tag;
            page.RadioButtons[2].CheckedChanged += (s, e1) => level = (int)(s as TaskDialogRadioButton).Tag;

            TaskDialogButton result = TaskDialog.ShowDialog(this, page);
            txtResult.Text = $"{result};    Selected RedioButton: {level}";

            if (result.Tag is int resultingMines)
                Console.WriteLine($"Playing with {resultingMines} mines...");
            else
                Console.WriteLine("User canceled.");
        }
    }
}
