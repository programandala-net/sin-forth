\ lib/s-literal.fs

\ This file is part of Sin Forth.

\ This file adds `sliteral` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
