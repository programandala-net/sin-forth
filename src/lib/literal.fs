\ lib/literal.fs

\ This file is part of Sin Forth.

\ This file adds `s-p-0` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012110151.
\ See change log at the end of the file.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: literal ( x -- )
  h ldp#, \ ld hl,x
  target{ push-hl } ;

  \ doc{
  \
  \ literal ( x -- )
  \
  \ Compile _x_ in the current definition.
  \
  \ ``literal`` is a compiler word, i.e. it is always executed.
  \
  \ See also: `lit`, `cliteral`, `2literal`, `xliteral`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Start.
\
\ 2020-12-11: Update the search-order selection words.
