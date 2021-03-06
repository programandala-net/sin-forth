\ lib/here.fs

\ This file is part of Sin Forth.

\ This file adds `here` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261533.
\ See change log at the end of the file.

\ ==============================================================

require d-p.fs   \ `dp`
require fetch.fs \ `@`

get-order get-current

target-definitions

: here ( -- a ) dp @ ;

  \ doc{
  \
  \ here ( -- a )
  \
  \ Return the data-space pointer _a_.
  \
  \ // XXX TODO
  \ // See also: `dp`, `limit`, `unused`, `there`.
  \ See also: `dp`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
\
\ 2020-12-11: Document.
\
\ 2020-12-26: Fix the file header.
