\ lib/s-backslash-quote.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230505T1252+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require s-literal.fs   \ `sliteral`

get-order get-current

compiler-definitions

warnings @  warnings off

: s\" ( "ccc<quote>" -- )
  \"-parse save-mem compiler{ sliteral } ;

warnings !

  \ doc{
  \
  \ s"
  \   Compilation: ( "ccc<quote>" -- )
  \   Run-time:    ( -- ca len )
  \ "s-quote"

  \ Compilation:
  \
  \ Parse the the string _ccc_ delimited by a double quote, using the
  \ translation rules below, and execute `sliteral` to compile it.
  \
  \ Translation rules:
  \
  \ Characters are processed  one at a  time and appended  to the
  \ string. If the character is a `{backslash}' character  it is
  \ processed by parsing  and substituting one or  more characters as
  \ follows, where the character after the backslash is case
  \ sensitive:

  \ |===
  \ | Code                   | Description                                                             | Difference in ZX Spectrum
  \
  \ | {backslash}a           | BEL (alert, ASCII 7)                                                    | edit
  \ | {backslash}b           | BS  (backspace, ASCII 8)                                                | cursor left
  \ | {backslash}e           | ESC (escape, ASCII 27)                                                  |
  \ | {backslash}f           | FF (form feed, ASCII 12)                                                | delete/backspace
  \ | {backslash}l           | LF (line feed, ASCII 10)                                                | cursor down
  \ | {backslash}m           | CR/LF pair (ASCII 13, 10)                                               |
  \ | {backslash}n           | newline (host system dependent, e.g., CR/LF, CR, LF, LF/CR)             |
  \ | {backslash}q           | double-quote (ASCII 34)                                                 |
  \ | {backslash}r           | CR (carriage return, ASCII 13)                                          |
  \ | {backslash}t           | HT (horizontal tab, ASCII 9)                                            | cursor right
  \ | {backslash}v           | VT (vertical tab, ASCII 11)                                             | cursor up
  \ | {backslash}z           | NUL (no character, ASCII 0)                                             |
  \ | {backslash}"           | double-quote (ASCII 34)                                                 |
  \ | {backslash}x<D><D>     | character resulting from the conversion of these two hexadecimal digits |
  \ | {backslash}{backslash} | backslash itself (ASCII 92)                                             |
  \ |===

  \ Run-time:
  \
  \ Return the compiled string _ca len_.
  \
  \ See also: `s"`, `slit`, `literal`.
  \
  \ }doc

set-current set-order
