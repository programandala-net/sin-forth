\ lib/s-literal.fs

\ This file is part of Sin Forth.

\ This file adds `sliteral` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260048.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-13: Update: Remove `target{`.
\
\ 2020-12-26: Complete.
