\ lib/s-quote.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230505T1125+0200.

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

: s" ( "ccc<quote>" -- )
  '"' parse save-mem compiler{ sliteral } ;

warnings !

  \ doc{
  \
  \ s"
  \   Compilation: ( "ccc<quote>" -- )
  \   Run-time:    ( -- ca len )
  \ "s-quote"

  \ Compilation: Parse the the string _ccc_ delimited by a double
  \ quote and execute `sliteral` to compile it.
  \
  \ Run-time: Return the compiled string _ca len_.
  \
  \ See also: `slit`, `literal`.
  \
  \ }doc

set-current set-order
