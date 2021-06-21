//
// Copyright 2021 Delphinus Consulting, LLC
//
// This file is part of Delphinus Verifier.
//
// Delphinus Verifier is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Delphinus Verifier is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Delphinus Verifier.  If not, see <https://www.gnu.org/licenses/>.
//
// Author:
// Jonathan W. Platt
// Datasoft, Inc.
// www.jwplatt.com
//
// These sources eschew elseif statements and use braces on their own lines for code block clarity.
// Please follow this format.  Reformatting otherwise will muddy the commit diff.
//
using System;
using System.Windows.Forms;

namespace Delphinus
{
    static class DelphinusVerifier
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VerifierForm());
        }
    }
}
