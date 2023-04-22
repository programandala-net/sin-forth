\ lib/s-literal.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require s-lit.fs   \ `slit`

get-order get-current

compiler-definitions

: sliteral ( ca len -- )
  slit t-s, ;

  \ doc{
  \
  \ sliteral
  \   Compilation: ( ca len -- )
  \   Run-time:    ( -- ca len )
  \ "s-literal"

  \ Compilation: Compile the string _ca len_ into data space and
  \ the code required to put it on the stack.
  \
  \ Run-time: Return the compiled string _ca len_.
  \
  \ // XXX TODO // See also: `lit`, `cliteral`, `2literal`,
  \ `xliteral`.
  \
  \ See also: `slit`, `literal`.
  \
  \ }doc

set-current set-order
